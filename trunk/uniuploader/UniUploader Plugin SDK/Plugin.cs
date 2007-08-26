using System;
using System.Collections;
using System.Windows.Forms;
using PluginInterface;

namespace Plugin
{
	/// <summary>
	/// Summary description for Plugin.
	/// </summary>
	public class Plugin : System.Windows.Forms.UserControl, IPlugin
	{
		string myPluginName = "Plugin";
		string myPluginAuthor = "Author name - email@xxxxxx.xxx";
		string myPluginDescription = "Adds Functionality to UU";
		string myPluginVersion = "1.0.0";
		private System.Windows.Forms.GroupBox aceGrpbox;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Plugin()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.aceGrpbox = new System.Windows.Forms.GroupBox();
			this.SuspendLayout();
			// 
			// aceGrpbox
			// 
			this.aceGrpbox.Location = new System.Drawing.Point(8, 8);
			this.aceGrpbox.Name = "aceGrpbox";
			this.aceGrpbox.Size = new System.Drawing.Size(472, 216);
			this.aceGrpbox.TabIndex = 2;
			this.aceGrpbox.TabStop = false;
			this.aceGrpbox.Text = "Plugin";
			// 
			// Plugin
			// 
			this.Controls.Add(this.aceGrpbox);
			this.Name = "Plugin";
			this.Size = new System.Drawing.Size(624, 392);
			this.ResumeLayout(false);

		}
		#endregion

		public void message(Hashtable idata)
		{
			string msg = (string)idata["message"];
			msg = msg.ToUpper();
			Hashtable data = (Hashtable)idata["data"];
			switch(msg)
			{
				case "UU_STARTING":
					Hashtable h = new Hashtable();
					h["line"] = myPluginName+" Version "+myPluginVersion+" by "+myPluginAuthor+" Ready!";
					this.Host.plugin_send_message("debugLine",h,this);
					break;
				default:
					//Hashtable h = new Hashtable();
					//h["line"] = myPluginName+": Unknown message \""+msg+"\" from UU";
					//this.Host.plugin_send_message("debugLine",h,this);
					break;
			}
		}
		#region IPlugin Members
		//you must be brave to mess with this stuff :P
		IPluginHost myPluginHost = null;

		
        
		void PluginInterface.IPlugin.Dispose()
		{
			// TODO:  Add ctlMain.PluginInterface.IPlugin.Dispose implementation
		}

		public string Description
		{
			get
			{
				// TODO:  Add ctlMain.Description getter implementation
				return myPluginDescription;
			}
		}

		public string Author
		{
			get
			{
				// TODO:  Add ctlMain.Author getter implementation
				return myPluginAuthor;
			}
		}

		public IPluginHost Host
		{
			get
			{
				// TODO:  Add ctlMain.Host getter implementation
				return myPluginHost;
			}
			set
			{
				myPluginHost = value;
			}
		}

		public void Initialize()
		{
			// TODO:  Add ctlMain.Initialize implementation
		}

		private void butSend_Click(object sender, System.EventArgs e)
		{
			//this.Host.Feedback(this.txtFeedback.Text, this);
		}

		/*
		public string Name
		{
			get
			{
				// TODO:  Add ctlMain.Name getter implementation
				return myPluginName;
			}
		}
		*/
		public UserControl MainInterface
		{
			get
			{
				// TODO:  Add ctlMain.MainInterface getter implementation
				return this;
			}
		}

		public string Version
		{
			get
			{
				// TODO:  Add ctlMain.Version getter implementation
				return myPluginVersion;
			}
		}

		#endregion


	}
}
