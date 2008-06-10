using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Threading;
using System.Xml;
using System.IO;
using System.Text;
using PluginInterface;

namespace Ace
{
	/// <summary>
	/// Summary description for Ace.
	/// </summary>
	public class Ace : System.Windows.Forms.UserControl, IPlugin
	{
		string myPluginName = "Ace";
		string myPluginAuthor = "Matt Miller";
		string myPluginDescription = "This adds the WoWAce Addon Repository to UU";
		string myPluginVersion = "1.0.0";

		private System.Windows.Forms.GroupBox aceGrpbox;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.GroupBox groupBox13;
		private System.Windows.Forms.RadioButton radioButton4;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.TabControl tabControl3;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.LinkLabel linkLabel3;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TabPage tabPage6;
		private System.Windows.Forms.CheckedListBox clb_acelist;
		private System.Windows.Forms.ProgressBar aceProgress;
		private System.Windows.Forms.Label label21;
		public ThreadStart acejob;// = new ThreadStart(upload);
		public Thread aceUploadThread;// = new Thread(job);
				public Hashtable acelist = new Hashtable();
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Ace()
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
			this.button9 = new System.Windows.Forms.Button();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.groupBox13 = new System.Windows.Forms.GroupBox();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.tabControl3 = new System.Windows.Forms.TabControl();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.linkLabel3 = new System.Windows.Forms.LinkLabel();
			this.label17 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.clb_acelist = new System.Windows.Forms.CheckedListBox();
			this.aceProgress = new System.Windows.Forms.ProgressBar();
			this.label21 = new System.Windows.Forms.Label();
			this.aceGrpbox.SuspendLayout();
			this.groupBox13.SuspendLayout();
			this.tabControl3.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.SuspendLayout();
			// 
			// aceGrpbox
			// 
			this.aceGrpbox.Controls.Add(this.button9);
			this.aceGrpbox.Controls.Add(this.checkBox2);
			this.aceGrpbox.Controls.Add(this.groupBox13);
			this.aceGrpbox.Controls.Add(this.tabControl3);
			this.aceGrpbox.Controls.Add(this.clb_acelist);
			this.aceGrpbox.Controls.Add(this.aceProgress);
			this.aceGrpbox.Controls.Add(this.label21);
			this.aceGrpbox.Location = new System.Drawing.Point(8, 8);
			this.aceGrpbox.Name = "aceGrpbox";
			this.aceGrpbox.Size = new System.Drawing.Size(472, 216);
			this.aceGrpbox.TabIndex = 1;
			this.aceGrpbox.TabStop = false;
			this.aceGrpbox.Text = "Ace Addons";
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(376, 112);
			this.button9.Name = "button9";
			this.button9.TabIndex = 55;
			this.button9.Text = "Update";
			// 
			// checkBox2
			// 
			this.checkBox2.Location = new System.Drawing.Point(368, 144);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(88, 16);
			this.checkBox2.TabIndex = 54;
			this.checkBox2.Text = "Auto Update";
			// 
			// groupBox13
			// 
			this.groupBox13.Controls.Add(this.radioButton4);
			this.groupBox13.Controls.Add(this.radioButton3);
			this.groupBox13.Controls.Add(this.radioButton1);
			this.groupBox13.Controls.Add(this.radioButton2);
			this.groupBox13.Location = new System.Drawing.Point(144, 112);
			this.groupBox13.Name = "groupBox13";
			this.groupBox13.Size = new System.Drawing.Size(136, 88);
			this.groupBox13.TabIndex = 53;
			this.groupBox13.TabStop = false;
			this.groupBox13.Text = "Sort By";
			// 
			// radioButton4
			// 
			this.radioButton4.Location = new System.Drawing.Point(8, 64);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(104, 16);
			this.radioButton4.TabIndex = 54;
			this.radioButton4.Text = "Author";
			// 
			// radioButton3
			// 
			this.radioButton3.Location = new System.Drawing.Point(8, 48);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(104, 16);
			this.radioButton3.TabIndex = 53;
			this.radioButton3.Text = "TOC";
			// 
			// radioButton1
			// 
			this.radioButton1.Checked = true;
			this.radioButton1.Location = new System.Drawing.Point(8, 16);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(104, 16);
			this.radioButton1.TabIndex = 51;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Name";
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(8, 32);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(104, 16);
			this.radioButton2.TabIndex = 52;
			this.radioButton2.Text = "Category";
			// 
			// tabControl3
			// 
			this.tabControl3.Controls.Add(this.tabPage2);
			this.tabControl3.Controls.Add(this.tabPage5);
			this.tabControl3.Controls.Add(this.tabPage4);
			this.tabControl3.Controls.Add(this.tabPage6);
			this.tabControl3.Location = new System.Drawing.Point(144, 16);
			this.tabControl3.Name = "tabControl3";
			this.tabControl3.SelectedIndex = 0;
			this.tabControl3.Size = new System.Drawing.Size(304, 88);
			this.tabControl3.TabIndex = 50;
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(296, 62);
			this.tabPage2.TabIndex = 0;
			this.tabPage2.Text = "Description";
			// 
			// tabPage5
			// 
			this.tabPage5.Location = new System.Drawing.Point(4, 22);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Size = new System.Drawing.Size(296, 62);
			this.tabPage5.TabIndex = 3;
			this.tabPage5.Text = "Author";
			this.tabPage5.Visible = false;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.linkLabel3);
			this.tabPage4.Controls.Add(this.label17);
			this.tabPage4.Controls.Add(this.label20);
			this.tabPage4.Controls.Add(this.label19);
			this.tabPage4.Controls.Add(this.label18);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(296, 62);
			this.tabPage4.TabIndex = 2;
			this.tabPage4.Text = "Version";
			this.tabPage4.Visible = false;
			// 
			// linkLabel3
			// 
			this.linkLabel3.Location = new System.Drawing.Point(152, 24);
			this.linkLabel3.Name = "linkLabel3";
			this.linkLabel3.Size = new System.Drawing.Size(96, 16);
			this.linkLabel3.TabIndex = 4;
			this.linkLabel3.TabStop = true;
			this.linkLabel3.Text = "Download Zip File";
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(152, 8);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(40, 16);
			this.label17.TabIndex = 3;
			this.label17.Text = "Stable:";
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(8, 24);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(32, 16);
			this.label20.TabIndex = 2;
			this.label20.Text = "TOC:";
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(8, 8);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(48, 16);
			this.label19.TabIndex = 1;
			this.label19.Text = "Version:";
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(8, 40);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(56, 16);
			this.label18.TabIndex = 0;
			this.label18.Text = "Published:";
			// 
			// tabPage6
			// 
			this.tabPage6.Location = new System.Drawing.Point(4, 22);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Size = new System.Drawing.Size(296, 62);
			this.tabPage6.TabIndex = 4;
			this.tabPage6.Text = "Dependencies";
			this.tabPage6.Visible = false;
			// 
			// clb_acelist
			// 
			this.clb_acelist.Location = new System.Drawing.Point(8, 16);
			this.clb_acelist.Name = "clb_acelist";
			this.clb_acelist.Size = new System.Drawing.Size(128, 184);
			this.clb_acelist.TabIndex = 49;
			// 
			// aceProgress
			// 
			this.aceProgress.Location = new System.Drawing.Point(288, 184);
			this.aceProgress.Name = "aceProgress";
			this.aceProgress.Size = new System.Drawing.Size(168, 16);
			this.aceProgress.TabIndex = 48;
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(288, 168);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(100, 16);
			this.label21.TabIndex = 47;
			this.label21.Text = "Progress";
			// 
			// Ace
			// 
			this.Controls.Add(this.aceGrpbox);
			this.Name = "Ace";
			this.Size = new System.Drawing.Size(488, 232);
			this.VisibleChanged += new System.EventHandler(this.Ace_VisibleChanged);
			this.aceGrpbox.ResumeLayout(false);
			this.groupBox13.ResumeLayout(false);
			this.tabControl3.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
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
		private void Ace_VisibleChanged(object sender, System.EventArgs e)
		{
			acejob = new ThreadStart(aceUpdateList);
			aceUploadThread = new Thread(acejob);
			aceUploadThread.Name = "aceThread";		
			aceUploadThread.Start();
		}
		public void aceUpdateList()
		{
			acelist = new Hashtable();
			clb_acelist.Enabled = false;
			//string xml = "";
			aceProgress.Value = 0;
			//MemoryStream memStream = this.Host.Feedback("http://files.wowace.com/latest.xml",this);
			//this.Host.Feedback("http://files.wowace.com/latest.xml",this);
			Hashtable h = new Hashtable();
			h["line"] = "ACE TEST MESSAGE";
			this.Host.plugin_send_message("debugLine",h,this);
			this.Host.plugin_send_message("asdf",h,this);
			/*
			memStream.Position = 0;
			xml = Encoding.UTF8.GetString(memStream.ToArray());
			XmlDocument x = new XmlDocument();
			x.InnerXml = xml;
			foreach(XmlNode node in x)
			{
				if (node.Name == "rss")
				{
					foreach(XmlNode channel in node)
					{
						foreach(XmlNode item in channel)
						{
							if (item.Name == "item")
							{
								Hashtable parsedItem = aceParseItem(item);
								String title = (String)parsedItem["title"];
								acelist[title] = parsedItem;
							}
						}
					}
				}
			}
			pop_ace_gui();
			clb_acelist.Enabled = true;
			*/
		}
		
		private void pop_ace_gui()
		{
			clb_acelist.Items.Clear();
			Hashtable aceAddon;
			IDictionaryEnumerator en = acelist.GetEnumerator();
			while (en.MoveNext())
			{
				aceAddon = (Hashtable) acelist [en.Key];
				clb_acelist.Items.Add((string)aceAddon["title"]);
			}
		}

		public Hashtable aceParseItem(XmlNode item)
		{
			Hashtable parsedItem = new Hashtable();
			ArrayList dependencies = new ArrayList();
			foreach(XmlNode itemInfo in item)
			{
				switch(itemInfo.Name)
				{
					case "title":
						parsedItem["title"] = itemInfo.InnerText;
						break;
					case "description":
						parsedItem["description"] = itemInfo.InnerText;
						break;
					case "wowaddon:interface":
						parsedItem["interface"] = itemInfo.InnerText;
						break;
					case "wowaddon:version":
						parsedItem["version"] = itemInfo.InnerText;
						break;
					case "guid":
						parsedItem["guid"] = itemInfo.InnerText;
						break;
					case "category":
						parsedItem["category"] = itemInfo.InnerText;
						break;
					case "author":
						parsedItem["author"] = itemInfo.InnerText;
						break;
					case "enclosure":
						parsedItem["length"] = itemInfo.Attributes["length"].InnerText;
						parsedItem["type"] = itemInfo.Attributes["type"].InnerText;
						parsedItem["url"] = itemInfo.Attributes["url"].InnerText;
						break;
					case "pubDate":
						parsedItem["pubdate"] = itemInfo.InnerText;
						break;
					case "wowaddon:dependencies":
						dependencies.Add(itemInfo.InnerText);
						break;
					default:
						break;
				}
			}
			parsedItem["dependencies"] = dependencies;
			return parsedItem;
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
