/*
 * Created by SharpDevelop.
 * User: HIV1GA
 * Date: 28/05/2019
 * Time: 01:25 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace p01_HinojosaAcosta
{
	partial class AddAgents
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button buttonAcceptInitVertex;
		private System.Windows.Forms.Label labelNumberAgent;
		private System.Windows.Forms.Label labelInitVertexAgent;
		private System.Windows.Forms.ComboBox comboBoxAgentStartVertex;
		private System.Windows.Forms.Label labelDestineVertex;
		private System.Windows.Forms.ComboBox comboBoxDestineVertex;
		private System.Windows.Forms.Button buttonDeletePrey;
		private System.Windows.Forms.Button labelInterchangeVertices;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddAgents));
			this.buttonAcceptInitVertex = new System.Windows.Forms.Button();
			this.labelNumberAgent = new System.Windows.Forms.Label();
			this.labelInitVertexAgent = new System.Windows.Forms.Label();
			this.comboBoxAgentStartVertex = new System.Windows.Forms.ComboBox();
			this.labelDestineVertex = new System.Windows.Forms.Label();
			this.comboBoxDestineVertex = new System.Windows.Forms.ComboBox();
			this.buttonDeletePrey = new System.Windows.Forms.Button();
			this.labelInterchangeVertices = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// buttonAcceptInitVertex
			// 
			this.buttonAcceptInitVertex.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.buttonAcceptInitVertex.Location = new System.Drawing.Point(229, 182);
			this.buttonAcceptInitVertex.Name = "buttonAcceptInitVertex";
			this.buttonAcceptInitVertex.Size = new System.Drawing.Size(142, 59);
			this.buttonAcceptInitVertex.TabIndex = 7;
			this.buttonAcceptInitVertex.Text = "Accept";
			this.buttonAcceptInitVertex.UseVisualStyleBackColor = true;
			this.buttonAcceptInitVertex.Click += new System.EventHandler(this.ButtonAcceptInitVertexClick);
			// 
			// labelNumberAgent
			// 
			this.labelNumberAgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelNumberAgent.Location = new System.Drawing.Point(164, 36);
			this.labelNumberAgent.Name = "labelNumberAgent";
			this.labelNumberAgent.Size = new System.Drawing.Size(186, 27);
			this.labelNumberAgent.TabIndex = 6;
			this.labelNumberAgent.Text = "Agent ";
			// 
			// labelInitVertexAgent
			// 
			this.labelInitVertexAgent.Location = new System.Drawing.Point(39, 91);
			this.labelInitVertexAgent.Name = "labelInitVertexAgent";
			this.labelInitVertexAgent.Size = new System.Drawing.Size(117, 27);
			this.labelInitVertexAgent.TabIndex = 5;
			this.labelInitVertexAgent.Text = "Init Vertex";
			// 
			// comboBoxAgentStartVertex
			// 
			this.comboBoxAgentStartVertex.FormattingEnabled = true;
			this.comboBoxAgentStartVertex.Location = new System.Drawing.Point(163, 88);
			this.comboBoxAgentStartVertex.Name = "comboBoxAgentStartVertex";
			this.comboBoxAgentStartVertex.Size = new System.Drawing.Size(207, 28);
			this.comboBoxAgentStartVertex.TabIndex = 4;
			// 
			// labelDestineVertex
			// 
			this.labelDestineVertex.Location = new System.Drawing.Point(39, 125);
			this.labelDestineVertex.Name = "labelDestineVertex";
			this.labelDestineVertex.Size = new System.Drawing.Size(117, 27);
			this.labelDestineVertex.TabIndex = 11;
			this.labelDestineVertex.Text = "Destine Vertex";
			// 
			// comboBoxDestineVertex
			// 
			this.comboBoxDestineVertex.FormattingEnabled = true;
			this.comboBoxDestineVertex.Location = new System.Drawing.Point(163, 122);
			this.comboBoxDestineVertex.Name = "comboBoxDestineVertex";
			this.comboBoxDestineVertex.Size = new System.Drawing.Size(207, 28);
			this.comboBoxDestineVertex.TabIndex = 10;
			// 
			// buttonDeletePrey
			// 
			this.buttonDeletePrey.Location = new System.Drawing.Point(89, 194);
			this.buttonDeletePrey.Name = "buttonDeletePrey";
			this.buttonDeletePrey.Size = new System.Drawing.Size(105, 35);
			this.buttonDeletePrey.TabIndex = 12;
			this.buttonDeletePrey.Text = "Delete";
			this.buttonDeletePrey.UseVisualStyleBackColor = true;
			this.buttonDeletePrey.Click += new System.EventHandler(this.ButtonDeletePreyClick);
			// 
			// labelInterchangeVertices
			// 
			this.labelInterchangeVertices.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.labelInterchangeVertices.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("labelInterchangeVertices.BackgroundImage")));
			this.labelInterchangeVertices.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.labelInterchangeVertices.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelInterchangeVertices.Location = new System.Drawing.Point(376, 88);
			this.labelInterchangeVertices.Name = "labelInterchangeVertices";
			this.labelInterchangeVertices.Size = new System.Drawing.Size(46, 61);
			this.labelInterchangeVertices.TabIndex = 14;
			this.labelInterchangeVertices.UseVisualStyleBackColor = false;
			this.labelInterchangeVertices.Click += new System.EventHandler(this.LabelInterchangeVerticesClick);
			// 
			// AddAgents
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(459, 275);
			this.Controls.Add(this.labelInterchangeVertices);
			this.Controls.Add(this.buttonDeletePrey);
			this.Controls.Add(this.labelDestineVertex);
			this.Controls.Add(this.comboBoxDestineVertex);
			this.Controls.Add(this.buttonAcceptInitVertex);
			this.Controls.Add(this.labelNumberAgent);
			this.Controls.Add(this.labelInitVertexAgent);
			this.Controls.Add(this.comboBoxAgentStartVertex);
			this.Name = "AddAgents";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "AddAgents";
			this.ResumeLayout(false);

		}
	}
}
