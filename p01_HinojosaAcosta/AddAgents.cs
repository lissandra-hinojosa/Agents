using System;
using System.Drawing;
using System.Windows.Forms;
using p01_HinojosaAcosta;
using System.Collections.Generic;

namespace p01_HinojosaAcosta
{
	public partial class AddAgents : Form
	{
		int type;
		int initVertex;
		int destineVertex;
		
		public enum Type{
			Init_Destine, //WithDestine
			Init_NoDestine, //No Destine
		}
		
		public int InitVertex{
			get{return initVertex;}
		}
		
		public int DestineVertex{
			get{return destineVertex;}
		}
		
		
		//Change Destine from agent as initvertex
//		public AddAgents(Agent a, List<int>itemsDestine){
//			this.type = (int)Type.NoInit_Destine;
//			comboBoxAgentStartVertex.Items.Add(a.DestineVertex.Id);
//			comboBoxAgentStartVertex.DropDownStyle = ComboBoxStyle.DropDownList; //Read only
//			comboBoxDestineVertex.DataSource = itemsDestine;
//			comboBoxDestineVertex.DropDownStyle = ComboBoxStyle.DropDownList; //Read Only
//			comboBoxDestineVertex.SelectedIndex = 0;
//		}
		
		//Agent already has destine and init, so interchange
		//PREDATOR-PREY MODALITY
		public AddAgents(Agent a, List<int>itemsInit, List<int>itemsDestine){
			InitializeComponent();
			this.type = (int)Type.Init_Destine;
			labelNumberAgent.Text = "Agent # "+a.Id;
			comboBoxAgentStartVertex.DataSource = itemsInit;
			comboBoxAgentStartVertex.DropDownStyle = ComboBoxStyle.DropDownList; //Read Only
			comboBoxAgentStartVertex.SelectedIndex = a.DestineVertex.Id-1;
			comboBoxDestineVertex.DataSource = itemsDestine;
			comboBoxDestineVertex.DropDownStyle = ComboBoxStyle.DropDownList; //Read Only
			comboBoxDestineVertex.SelectedIndex = a.InitVertex.Id-1;
		}

		
		public AddAgents(List<int>itemsInit, List<int>itemsDestine, int agentNum, int type){
			
			InitializeComponent();
			buttonDeletePrey.Enabled = false;
			buttonDeletePrey.Visible = false;
			labelInterchangeVertices.Enabled = false;
			labelInterchangeVertices.Visible = false;
			labelNumberAgent.Text = "Agent # "+agentNum;
			comboBoxAgentStartVertex.DataSource = itemsInit;
			comboBoxAgentStartVertex.DropDownStyle = ComboBoxStyle.DropDownList; //Read Only
			comboBoxAgentStartVertex.SelectedIndex = 0;
			this.type = type;
			if(this.type == (int)Type.Init_Destine){
				comboBoxDestineVertex.DataSource = itemsDestine;
				comboBoxDestineVertex.DropDownStyle = ComboBoxStyle.DropDownList; //Read Only
				comboBoxDestineVertex.SelectedIndex = 0;
			}
			else{
				comboBoxDestineVertex.Hide();
				labelDestineVertex.Hide();
			}
			
		}
		void ButtonAcceptInitVertexClick(object sender, EventArgs e)
		{
			initVertex = (int)comboBoxAgentStartVertex.SelectedItem;
			if(type == (int)Type.Init_Destine){
				destineVertex = (int)comboBoxDestineVertex.SelectedItem;
			}
			this.DialogResult = DialogResult.OK;
		}
		void ButtonDeletePreyClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Abort;
		}
		void LabelInterchangeVerticesClick(object sender, EventArgs e)
		{
			int auxIndex = (int)comboBoxAgentStartVertex.SelectedIndex;
			comboBoxAgentStartVertex.SelectedIndex = comboBoxDestineVertex.SelectedIndex;
			comboBoxDestineVertex.SelectedIndex = auxIndex;
		}
		
		
		
		
	}
}