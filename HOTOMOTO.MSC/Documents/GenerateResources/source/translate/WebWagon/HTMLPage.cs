//WebWagon: An HTML Container Class 
//
//Jon Vote - 2004
//
//Idioma Software Inc. 
//www.idioma-software.com
//www.skycoder.com 
//jon@idioma-software.com 
//'541-488-1972 (USA)

using System;
using System.Net;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;

namespace WebWagon	
{
	/// <summary>
	/// HTMLPage: HTML Container Class
	/// </summary>
	public class HTMLPage
	{
		private string m_strURL = ""; 
		private string m_strSource = ""; 
		private string m_strHost = ""; 
		private string m_strCharacterSet = ""; 
		private string m_strContentEncoding = ""; 
		private string m_strContentLength = ""; 
		private string m_strContentType = ""; 
		private string m_strLastModified = ""; 
		private int m_intTimeOutSeconds = 30;
		
		//Feedback Events
		public delegate void LoadStatusHandler(string URL, string Description); 
		public event LoadStatusHandler LoadStatus; 
		public delegate void LoadProgressHandler(string URL, int Maximum, int Value);
		public event LoadProgressHandler LoadProgress;

		//URL
		public string URL
		{
			get	{return(m_strURL);}
		}

		//Host
		public string Host
		{
			get	{return(m_strHost);}
		}

		//Source
		public string Source
		{
			get
			{
				return(m_strSource);
			}
			set
			{
				m_strSource = value;
	            m_strHost = "";
		        m_strCharacterSet = "";
			    m_strContentEncoding = "";
				m_strContentLength = "";
	            m_strContentType = "";
		        m_strLastModified = "";
			}
		}
		
		//CharacterSet
		public string CharacterSet
		{
			get	{return(m_strCharacterSet);}
		}

		//CharacterSet
		public string ContentEncoding
		{
			get	{return(m_strContentEncoding);}
		}

		//CharacterSet
		public string ContentLength
		{
			get {return(m_intContentLength);}
		}

		//ContentType
		public string ContentType
		{
			get {return(m_intContentType);}
		}

		//LastModified
		public string LastModified
		{
			get {return(m_strLastModified);}
		}

		//Head
		public string Head
		{
			get {return(m_strHead);}
		}

		//Title
		public string Title
		{
			get {return(m_strTitle);}
		}

		//Body
		public string Body
		{
			get {
				string strBody 
					= GetTagByName("Body", m_strSource);
				if (strBody == "")  
					strBody = this.Source;
				return(strBody);
			}
		}

		//Text
		public string Text
		{
			get 
			{
				RegEx r = new Regex("");
				RegexOptions opts 
					= RegexOptions.IgnoreCase | RegexOptions.Singleline;

				//Start with the Body
				string strText = Me.Body;

				//Remove comments 
				strText = StripComments(); 

				//Remove any SCRIPT blocks
				string strPattern = GetExpressionForTagContents("SCRIPT");
				strText = r.Replace(strText, strPattern, "", opts);

				//Remove the remaining tags
				strPattern = @"<[^>]*>";
				strText = r.Replace(strText, strPattern, " ", opts);

				//Convert ISO Characters 
				strText = ISOtoASCII(strText);

				//Remove double white spaces   
				System.Text.RegularExpressions.MatchCollection m;
				do
				{
					strText = r.Replace(strText, @"\s\s", " ");
						m = r.Matches(strText, @"\s\s");
				}
				while (m.Count > 0);

				return(Trim(strText));
			}
		}

		//LoadSource: Load a page from the Internet
		public bool LoadSource(string URL)
		{
			m_strURL = URL;
			//Make a guess of 40,000 if the content lenght is not not known
			const int DEFAULT_CONTENT_LENGTH = 40000;
			string strSource = "";
			string strHost = "";
			string strCharacterSet = "";
			string strContentEncoding = "";
			string intContentLength   = 0;
			string strContentType   = "";
			string strServer   = "";
			string strLastModified  = "";
			string intTotalLength   = 0;
			if (m_strURL = "")
				LoadStatus(m_strURL, "Error");
			else
			{
				try
				{
					LoadStatus(m_strURL, "Request");
					LoadProgress(m_strURL, 0, 0);
					HttpWebRequest hrqURL  = HttpWebRequest.Create(m_strURL);
					HttpWebResponse hrspURL  = hrqURL.GetResponse();
					StreamReader srdrInput 
						= new StringReader(hrspURL.GetResponseStream());
					char[]chrBuff = new char[255];
					int intLen;
					//Get the content length
					if (intContentLength <= 0)  
						intContentLength = DEFAULT_CONTENT_LENGTH;
					    LoadStatus(m_strURL, "Load");
						DateTime tmeExpire 
						= DateAdd(DateInterval.Second, 
						  m_intTimeOutSeconds, Now());
						do
						{
						  intLen = srdrInput.Read(chrBuff, 0, 256);
						  string strBuff = String(chrBuff, 0, intLen);
						  strSource = strSource & strBuff;
						  intTotalLength = intTotalLength + intLen;
						  if (intTotalLength > intContentLength)
								intContentLength = 2 * intTotalLength;
							LoadProgress(m_strURL, intContentLength,
								intTotalLength);
						if (DateDiff(DateInterval.Second, tmeExpire, Now()) > 0)
						  {
							LoadStatus(m_strURL, "Error");
							LoadSource = False;
							Exit Do;
						  }  
						} 
						while(intLen);

						srdrInput.Close();
						hrspURL.Close();
						strHost = hrspURL.ResponseUri.Host;
						strCharacterSet = hrspURL.CharacterSet;
						strContentEncoding = hrspURL.ContentEncoding;
						intContentLength = hrspURL.ContentLength;
						strContentType = hrspURL.ContentType;
						strLastModified = hrspURL.LastModified;
                        LoadStatus(m_strURL, "Complete");
						return(true);

				}
				catch (System.Net.WebException e)
				{
					LoadStatus(m_strURL, "error");
					return(false);
				}
			}
	        m_strHost = strHost;
		    m_strSource = strSource;
	        m_strCharacterSet = strCharacterSet;
		    m_strContentEncoding = strContentEncoding;
			m_intContentLength = intContentLength;
	        m_strContentType = strContentType;
		    m_strLastModified = strLastModified;

			LoadProgress(m_strURL, intTotalLength, intTotalLength);
		}

		
		//GetTagsByName: Returns all matches for TagName
		public string[] GetTagsByName(string TagName)
		{
				return(GetTagsByName(TagName, m_strSource));
	    }

		public string[] GetTagsByName(string TagName
			, string Source)
		{
			Regex r = new Regex(""); 
			RegexOptions opts 
				= RegexOptions.IgnoreCase | RegexOptions.Singleline;
			//Normally we will ignore comments
			if (TagName != "!")
				Source = StripComments();
			//Find the beginning position of each matching tag
			string strPattern 
				= "<(?<TagName>" & TagName & @")(>|\s+[^>]*>)";
			MatchCollection mc
				= r.Matches(Source, strPattern, opts);

			//Grab the contents of each matching tag 
			ArrayList strTagContents = new ArrayList();
			foreach(Match m in mc)
			{
				strTagContents.Add( GetTagByName(TagName, 
					Mid(Source, m.Groups("TagName").Index)));
				intIndex ++;
			}
			return(strTagContents.ToArray); 
		}

		//GetHRefs: Return all HRefs
		public string[] GetHRefs()
		{
			string strSource = StripComments();
			Regex  r 
				= new Regex(@"<a[^>]*href\s*=\s*""?(?<HRef>[^"">\s]*)""?[^>]*>", 
				RegexOptions.IgnoreCase | RegexOptions.Singleline);

			MatchCollection mc = r.Matches(Source);
			int intIndex = 0;
			ArrayList strHRefs = new ArrayList();
			foreach(Match m in mc)
			{
				string strHRef =  Trim(m.Groups("HRef").Value);
				if (strHRef != "")
					if (strHRef.Substring(0,1) != "#")
					   if (strHRef.Substring(0,1) == @"\")
						   strHRef = m_strHost & strHRef;
				if (String.Compare(strHRef.Substring(0,7),"http://",true) != 0)
					 strHRef = "http://" & strHRef; 
				strHRefs.Add(strHREf);
				return(strHRefs);
			}
		}

	    //HTMLPage
		public HTMLPage()
		{
		}

	public bool LoadSource(string URL)
{
	LoadStatus("URL", "Description");
	return(true);
}
}
}
