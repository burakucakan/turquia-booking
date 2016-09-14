using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using WebWagon;
using HttpUtils;
using System.Resources;
using System.IO;
using System.Threading; 
using System.Xml;


namespace ResxTranslator
{
	delegate void ShowProgressDelegate(int percentTranslated);

	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button TranslateBtn;
		private System.Windows.Forms.TextBox resxFileName;

		private string langPairSelected=String.Empty;
		private string filetypeChoice=String.Empty;
		private System.Windows.Forms.OpenFileDialog fileBrowseDlg;
		private System.Windows.Forms.Button fileBrowse;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.TextBox txtOutput;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.resxFileName = new System.Windows.Forms.TextBox();
			this.TranslateBtn = new System.Windows.Forms.Button();
			this.fileBrowseDlg = new System.Windows.Forms.OpenFileDialog();
			this.fileBrowse = new System.Windows.Forms.Button();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.txtOutput = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(40, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Root Path";
			// 
			// resxFileName
			// 
			this.resxFileName.Location = new System.Drawing.Point(152, 24);
			this.resxFileName.Name = "resxFileName";
			this.resxFileName.Size = new System.Drawing.Size(200, 20);
			this.resxFileName.TabIndex = 1;
			this.resxFileName.Text = "";
			// 
			// TranslateBtn
			// 
			this.TranslateBtn.Location = new System.Drawing.Point(152, 56);
			this.TranslateBtn.Name = "TranslateBtn";
			this.TranslateBtn.Size = new System.Drawing.Size(200, 32);
			this.TranslateBtn.TabIndex = 4;
			this.TranslateBtn.Text = "Generate Resx XML";
			this.TranslateBtn.Click += new System.EventHandler(this.TranslateBtn_Click);
			// 
			// fileBrowse
			// 
			this.fileBrowse.Location = new System.Drawing.Point(360, 24);
			this.fileBrowse.Name = "fileBrowse";
			this.fileBrowse.Size = new System.Drawing.Size(56, 24);
			this.fileBrowse.TabIndex = 5;
			this.fileBrowse.Text = "Browse";
			this.fileBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.fileBrowse.Click += new System.EventHandler(this.fileBrowse_Click);
			// 
			// txtOutput
			// 
			this.txtOutput.Location = new System.Drawing.Point(8, 96);
			this.txtOutput.Multiline = true;
			this.txtOutput.Name = "txtOutput";
			this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtOutput.Size = new System.Drawing.Size(968, 424);
			this.txtOutput.TabIndex = 6;
			this.txtOutput.Text = "";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(992, 534);
			this.Controls.Add(this.txtOutput);
			this.Controls.Add(this.fileBrowse);
			this.Controls.Add(this.TranslateBtn);
			this.Controls.Add(this.resxFileName);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(1000, 1000);
			this.MinimumSize = new System.Drawing.Size(440, 272);
			this.Name = "Form1";
			this.Text = "Translate";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}


		private void TranslateBtn_Click(object sender, System.EventArgs e)
		{
//			MessageBox.Show();
			txtOutput.Text = "<?xml version=\"1.0\" standalone=\"yes\"?><lines>" + AllResxFilesToXML(resxFileName.Text) + "</lines>";


//			string fileName = this.resxFileName.Text;
//			string outputFileName = this.outputFileName.Text;
//			if(fileName.Length == 0 || outputFileName.Length == 0)
//			{
//				MessageBox.Show(this,"Enter the input and output file names","Incomplete Data"); 
//				return;
//			}
//
//			this.TranslateBtn.Text = "Translating ...";
//			this.TranslateBtn.Enabled = false;
//			this.translationProgress.Visible = true;
//			Thread translateThread = new Thread(new ThreadStart(this.TranslateInThread));
//			translateThread.Start();
		}

//		private void TranslateInThread()
//		{
//			string type = filetypeChoice;
//			switch(type)
//			{
//				case "resx":
//					TranslateResx();
//					break;
//				case "js":
//					TranslateJS();
//					break;
//				default:
//					break;
//			}
//			this.TranslateBtn.Text = "Translate";
//			this.TranslateBtn.Enabled = true;
//			this.translationProgress.Value = 0;
//			this.translationProgress.Visible=false;
//		}
		private void Form1_Load(object sender, System.EventArgs e)
		{
//			this.translateOption.DataSource =HttpUtils.TranslateUtil.GetLangPairs();
			ArrayList allowedFileTypes = new ArrayList();
			allowedFileTypes.Add("resx");
			allowedFileTypes.Add("js");
//			this.fileType.DataSource = allowedFileTypes;

		}

		private void translateOption_SelectedIndexChanged(object sender, System.EventArgs e)
		{
//			langPairSelected=(String)translateOption.SelectedValue;
		}

		private void fileBrowse_Click(object sender, System.EventArgs e)
		{
//			fileBrowseDlg.InitialDirectory = @"C:\";
//			fileBrowseDlg.Title = "Select a File";
//			if(filetypeChoice == "resx")
//				fileBrowseDlg.Filter = "Resource Files|*.resx|XML Files|*.xml|All Files|*.*";
//			else
//				fileBrowseDlg.Filter = "JavaScript String Resource Files|*.js|All Files|*.*";
//			fileBrowseDlg.FilterIndex = 1;
//			if (fileBrowseDlg.ShowDialog() != DialogResult.Cancel)
//				resxFileName.Text = fileBrowseDlg.FileName;
//			else
//				resxFileName.Text = "";
			if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				resxFileName.Text = folderBrowserDialog1.SelectedPath.ToString() ;
			}

		}

		private string AllResxFilesToXML(string rootPath)
		{
			string strFinalXML;
			strFinalXML = "";
			foreach (string strDir in System.IO.Directory.GetDirectories(rootPath))
			{
				strFinalXML = strFinalXML + AllResxFilesToXML(strDir);
			}
			foreach (string strDoc in System.IO.Directory.GetFiles(rootPath))
			{
				if (strDoc.ToUpper().IndexOf(".RESX") > -1)
				{
					strFinalXML = strFinalXML + ResxFileToXML(strDoc);
				}
			}
			return strFinalXML;
		}

		private string clearXML(string strin)
		{
//			return strin.Replace(">","&gt;").Replace("<","&lt;").Replace("&","&amp;").Replace("'","&apos;").Replace("\"","&quot;");
			return strin;
		}

		private string ResxFileToXML(string fileName)
		{
			
			//Load the resx file specified
			
			//To get the total no of resource strings to be translated (for
			//progress bar) fastest way is to read resx as xml!
			XmlDocument rootNode = new XmlDocument();
			rootNode.Load(fileName);
			XmlNodeList dataNodes = rootNode.SelectNodes("//root/data"); 
			int totalStrings = dataNodes.Count;
			// Create a ResXResourceReader for the file items.resx.
			ResXResourceReader rsxr = new ResXResourceReader(fileName);
			// Create an IDictionaryEnumerator to iterate through the resources.
			IDictionaryEnumerator id = rsxr.GetEnumerator(); 
			long count=0;
			object[] pct;
			pct = new object[1];
			string strXMLDoc;

			strXMLDoc = "";


			// Iterate through the resources 
			foreach (DictionaryEntry d in rsxr) 
			{
				count++;

				if (d.Value.ToString() != "")
				{
					strXMLDoc = strXMLDoc + "<line><document>" + fileName + "</document><key>" + d.Key.ToString() + "</key><value><![CDATA[" + clearXML(d.Value.ToString()) + "]]></value></line>";
				}

			}
			//store back the resx file under the chosen language option
			return strXMLDoc;

//			rsxr.Close(); 
		}

		private void TranslateJS()
		{
			string fileName = this.resxFileName.Text;
//			string outputFileName = this.outputFileName.Text;
			//Load the js file specified
			// Read the file and display it line by line.
			string line,str;
			string delimStr = "\"";
			char [] delimiter = delimStr.ToCharArray();
			string [] split = null;

			StreamReader inputFile = new StreamReader(fileName);
//			StreamWriter outputFile = new StreamWriter(outputFileName);
			//Get the totalno of lines. No way other than reading till end!
			long totallines = 0;
			while((line = inputFile.ReadLine()) != null)
			{
				totallines++;
			}
			inputFile.Close();

			StreamReader inputresxFile = new StreamReader(fileName);
			ShowProgressDelegate showProgress =	new ShowProgressDelegate(ShowProgress);
			long count=0;
			object[] pct;
			pct = new object[1];
			while((line = inputresxFile.ReadLine()) != null)
			{
				//Check if the line starts with var
				count++;
				int percentTranslated = (int)(count*100/totallines);
				pct[0]=percentTranslated;
				this.Invoke(showProgress,pct);
				
				line.Trim();
				if(line.StartsWith("var"))
				{
					split = line.Split(delimiter);
					string resstr = TranslateString(split[1]);
					split[1]=resstr;
					str = String.Join("\"",split); 
				}
				else
					str = line;
//				outputFile.WriteLine(str);
			}
			inputresxFile.Close();
//			outputFile.Close(); 
		}

		private string TranslateString(string inputstring)
		{
			string strval = inputstring;
			string translatedtxt = strval;
			//Call translate
			try
			{
				HttpUtils.LangPair lngPair=(HttpUtils.LangPair)Enum.Parse(typeof(HttpUtils.LangPair),this.langPairSelected ,true);
				translatedtxt =   HttpUtils.TranslateUtil.GetTranslatedText(strval,lngPair);
			}
			catch(Exception ex)
			{
				//Do Nothing for now
				string msg = ex.Message; 
			}
			return translatedtxt;

		}

		private void fileType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
//			filetypeChoice=(String)fileType.SelectedValue;
		
		}


	
		private void ShowProgress(int percentTranslated)
		{
//			this.translationProgress.Value = percentTranslated;
		}

	
	
	
	
	}
}
