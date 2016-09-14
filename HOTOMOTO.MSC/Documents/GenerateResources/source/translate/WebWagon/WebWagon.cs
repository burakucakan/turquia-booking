//WebWagon: An HTML Container Class 
//
//Jon Vote - 2004
//
//Idioma Software Inc. 
//www.idioma-software.com
//www.skycoder.com 
//jon@idioma-software.com 
//
//'541-488-1972 (USA)

using System;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;
using System.Collections;
using System.Web; 

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
		private string m_strServerURL = "";
		private string m_strPathURL = "";
		private string m_strCharacterSet = ""; 
		private string m_strContentEncoding = ""; 
		private long m_lngContentLength = 0; 
		private string m_strContentType = ""; 
		private string m_strLastModified = ""; 
		private int m_intTimeOutSeconds = 30;
		private bool m_bCancel = false; 

		//Feedback Events
		public delegate void LoadStatusHandler(string URL, string Description); 
		public event LoadStatusHandler LoadStatus; 
		public delegate void LoadProgressHandler(string URL, long Maximum, long Value);
		public event LoadProgressHandler LoadProgress;

		//HTMLPage Constructor
		public HTMLPage()
		{
		}

		public void Dispose()
		{
			this.Cancel = true;
		}

		public bool Cancel 
		{
			get
			{
				return(m_bCancel);
			}
			set
			{
				m_bCancel = value;
			}
		 }

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

		//ServerURL
		public string ServerURL
		{
			get	{return(m_strServerURL);}
		}

		//PathURL
		public string PathURL
		{
			get	{return(m_strPathURL);}
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
				m_lngContentLength = 0;
				m_strContentType = "";
				m_strLastModified = "";
			}
		}
			
		//CharacterSet
		public string CharacterSet
		{
			get	{return(m_strCharacterSet);}
		}

		//ContentEncoding
		public string ContentEncoding
		{
			get	{return(m_strContentEncoding);}
		}

		//ContentLength
		public long ContentLength
		{
			get {return(m_lngContentLength);}
		}

		//ContentType
		public string ContentType
		{
			get {return(m_strContentType);}
		}

		//LastModified
		public string LastModified
		{
			get {return(m_strLastModified);}
		}

		//Head
		public string Head
		{
			get 
			{
				return(GetTagByName("Head", m_strSource));
			}
		}

		//Title
		public string Title
		{
			get 
			{
				//Remove Comments
				string strText = StripComments(m_strSource); 

				//Grab the Title Tag
				strText = GetTagByName("Title", strText);

				//Remove the opening/closing tags
				string strPattern = @"<[^>]*>";
				strText = Regex.Replace(strText, strPattern, "");

				return(strText.Trim());
			}
		}

	//Body
	public string Body
	{
		get 
		{
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
			Regex r = new Regex("");
			RegexOptions opts 
				= RegexOptions.IgnoreCase | RegexOptions.Singleline;

			//Start with the Body
			string strText = this.Body;

			//Remove Comments 
			strText = StripComments(strText); 

			//Remove any SCRIPT blocks
			string strPattern = GetExpressionForTagContents("SCRIPT");
			strText = Regex.Replace(strText, strPattern, "", opts); 

			//Remove the remaining tags
			strPattern = @"<[^>]*>";
			strText = Regex.Replace(strText, strPattern, " ", opts);

			//Convert ISO Characters 
			strText = ISOtoASCII(strText);
			strText = Regex.Replace(strText,"&amp;","&",opts);

			//Remove double white spaces   
			System.Text.RegularExpressions.MatchCollection m;
			do
			{
				strText = Regex.Replace(strText, @"\s\s", " ");
				m = Regex.Matches(strText, @"\s\s");
			}
			while (m.Count > 0);

			return(strText.Trim());
		}
	}

	//LoadSource: Load a page from the Internet
	public bool LoadSource(string URL)
	{
		//Set the URL property var
		m_strURL = URL;

		//Make a guess of 40,000 if the content lenght is not not known
		const int DEFAULT_CONTENT_LENGTH = 40000;
		string strSource = "";
		string strHost = "";
		string strServerURL  = "";
		string strPathURL  = "";
		string strCharacterSet = "";
		string strContentEncoding = "";
		long lngContentLength   = 0;
		string strContentType   = "";
		string strLastModified  = "";
		int intTotalLength   = 0;

		//Don't allow blank URL
		if ((m_strURL == null) || (m_strURL == ""))
		{
			if (LoadStatus != null)
			LoadStatus(m_strURL, "Error");
			return(false);
		}
		else
		{
			try
			{
				//Request the page from the server
				if (LoadStatus != null)
				LoadStatus(m_strURL, "Request");
				if (LoadProgress != null)
					LoadProgress(m_strURL, 0, 0);
				HttpWebRequest hrqURL = (HttpWebRequest)HttpWebRequest.Create(m_strURL);

				hrqURL.Method = "GET";
				hrqURL.ContentType = "application/x-www-form-urlencoded";
				hrqURL.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";

				//added by satish for proxy support!
				hrqURL.Proxy = (WebProxy) GlobalProxySelection.Select;
				hrqURL.Proxy.Credentials = CredentialCache.DefaultCredentials;
				HttpWebResponse hrspURL = (HttpWebResponse) hrqURL.GetResponse();
				//Added encoding - satish
				//Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
				StreamReader srdrInput 
					= new StreamReader
				(hrspURL.GetResponseStream(),Encoding.UTF8);
				char[]chrBuff = new char[256];
				int intLen;

				//Get the content length
				if (lngContentLength <= 0)  
					lngContentLength = DEFAULT_CONTENT_LENGTH;
				if (LoadStatus != null)
					LoadStatus(m_strURL, "Load");

				//Set the timeout 
				DateTime tmeExpire 
					= new DateTime(DateTime.Now.Ticks);
				tmeExpire 
					= tmeExpire.AddSeconds(m_intTimeOutSeconds);

				strSource = srdrInput.ReadToEnd(); 
				//Loop until the entire page has been loaded
				/*
				do
				{
					if (m_bCancel)
						return(false); 
					intLen = srdrInput.Read(chrBuff, 0, 256);
					string strBuff = new string(chrBuff, 0, intLen);
					strSource = strSource + strBuff;
					intTotalLength = intTotalLength + intLen;
					if (intTotalLength > lngContentLength)
						lngContentLength = 2 * intTotalLength;
					if (LoadProgress != null)
						LoadProgress(m_strURL, lngContentLength,
							intTotalLength);
					if (System.DateTime.Compare(tmeExpire,
						System.DateTime.Now ) < 0)  
					{
						if (LoadStatus != null)
							LoadStatus(m_strURL, "Error");
						return(false);
					}  
				} 
				while((intLen>0));
				*/
				srdrInput.Close();
				hrspURL.Close();

				//Save some useful values from the 
				//response object
				strHost = hrspURL.ResponseUri.Host;

				//URL to current path 
				Match m 
					= Regex.Match(hrspURL.ResponseUri.AbsoluteUri,  
				"/", RegexOptions.RightToLeft);
				if (m == null)
					strPathURL = hrspURL.ResponseUri.AbsoluteUri + "/";
				else
					strPathURL 
						= hrspURL.ResponseUri.AbsoluteUri.Substring(0, m.Index) + "/";

				//URL to server
				m = Regex.Match(hrspURL.ResponseUri.AbsoluteUri,  
					strHost, RegexOptions.RightToLeft  
						| RegexOptions.IgnoreCase);
				if (m == null)
					strServerURL = hrspURL.ResponseUri.AbsoluteUri;
				else
					strServerURL  
						= hrspURL.ResponseUri.AbsoluteUri.Substring  
							(0, m.Index + strHost.Length);

				strCharacterSet = hrspURL.CharacterSet;
				strContentEncoding = hrspURL.ContentEncoding;
				lngContentLength = hrspURL.ContentLength;
				strContentType = hrspURL.ContentType;
				strLastModified = hrspURL.LastModified.ToString();
				if (LoadStatus != null)
					LoadStatus(m_strURL, "Complete");
			}
			catch(Exception ex)
			{
				if (LoadStatus != null)
					LoadStatus(m_strURL, "error");
				return(false);
			}
		}
		//Set the property vars
		m_strHost = strHost;
		m_strServerURL = strServerURL;
		m_strPathURL = strPathURL;
		m_strSource = strSource;
		m_strCharacterSet = strCharacterSet;
		m_strContentEncoding = strContentEncoding;
		m_lngContentLength = lngContentLength;
		m_strContentType = strContentType;
		m_strLastModified = strLastModified;

		//Done.
		if (LoadProgress != null)
			LoadProgress(m_strURL, intTotalLength, intTotalLength);
		return(true);
	}

	//GetTagsByName: Returns all matches for TagName
	public string[] GetTagsByName(string TagName)
	{
		return(GetTagsByName(TagName, m_strSource));
	}
	public string[] GetTagsByName(string TagName
		, string Source)
	{
		RegexOptions opts 
			= RegexOptions.IgnoreCase | RegexOptions.Singleline;
		string strPattern;

		//Normally we will ignore comments
		if (TagName != "!")
		{
			Source = StripComments(Source);
			strPattern 
				= "<(?<TagName>" + TagName + @")(>|\s+[^>]*>)";
		}
		else
			strPattern 
				= "<(?<TagName>" + TagName + @")--";

		//Find the beginning position of each matching tag
		MatchCollection mc
			= Regex.Matches(Source, strPattern, opts);

		//Grab the contents of each matching tag 
		ArrayList strTagContents = new ArrayList();
		foreach(Match m in mc)
		{
			strTagContents.Add(GetTagByName(TagName, 
				Source.Substring
				 (m.Groups["TagName"].Index-1))); 
		}
		return((string[]) strTagContents.ToArray(typeof(String))); 
	}

		//GetHRefs: Return all HRefs
		public string[] GetHRefs()
		{
			//Strip the Comments
			string strSource = StripComments(m_strSource);

			//Match the HRef pattern
			Regex  r = new 
			 Regex(@"<a[^>]*href\s*=\s*""?(?<HRef>[^"">\s]*)""?[^>]*>", 
				RegexOptions.IgnoreCase | RegexOptions.Singleline);
			MatchCollection mc = r.Matches(Source);
			ArrayList strHRefs = new ArrayList();

			//Iterate through each match
			foreach(Match m in mc)
			{
				string strHRef =  m.Groups["HRef"].Value;
				strHRef.Trim();
				
				//Normalize the URL
				if (strHRef != "")
					if (Left(strHRef,1) != "#")
						if (Left(strHRef,1) == "/")
							strHRef = m_strServerURL + strHRef; 
						else
						{
							if (String.Compare(Left(strHRef,7),
						    	 "http://", true) != 0)
								if (String.Compare(Left(strHRef, 3),
									"www", true) == 0)
									strHRef = "http://" + strHRef;
								else
									strHRef = m_strPathURL + strHRef;
						}
				strHRefs.Add(strHRef);
			}

			//Return the list
			return(string[]) strHRefs.ToArray(typeof(string));  
		}

		//Left: Returns the left portion of a string
		private string Left(string strString, int intLen)
		{
			if (strString.Length <= intLen) 
				return(strString);
			else
				return(strString.Substring(0,intLen));
		}

		//GetAllTags: Return all tags in document
		public string[] GetAllTags()
		{
			string strPatternTag = @"<(?<Comment>!?)(?<Tag>[^>/\s]+)(>|\s+[^>]*>)";
			MatchCollection mc 
				= Regex.Matches(m_strSource, strPatternTag,  
				RegexOptions.IgnoreCase | RegexOptions.Singleline);
			int intLength = m_strSource.Length;
			int i;
			ArrayList strTagList = new ArrayList();
			string strTagName;
			string strTagData;
			for (i = 0; i < mc.Count; i++) 
			{
				if (m_bCancel)
					return null;
				//Get the tag name from the capture
				if (mc[i].Groups["Comment"].Value == "")  
					strTagName = mc[i].Groups["Tag"].Value;
				else
					strTagName = "!";

				//Find the Ending Tag starting at the current position 
				strTagData = GetTagByName(strTagName, 
					m_strSource.Substring(mc[i].Groups["Tag"].Index - 1));
				strTagList.Add(strTagData);
			}
		  return(string[]) strTagList.ToArray(typeof(string));
		}

		//GetExpressionForTagContents: Returns Regular Expression 
		//to extract a given tag's contents.
		private string GetExpressionForTagContents 
			(string strTagName)
		{
			string strPatternTag;
			if (strTagName == "!")
				strPatternTag = "<!.*?-->";
			else
				if (string.Compare(strTagName, "!doctype", true) == 0)
				strPatternTag = "<!doctype.*?>";
			else
				if (String.Compare(strTagName, "br", true) == 0) 
				strPatternTag = @"<br\s*/?\s*>";
			else
				strPatternTag 
					= @"<(" + strTagName + @")(>|\s+[^>]*>).*?</\1\s*>";
			return(strPatternTag);
		}

		//GetTagByName: Assumes tag exists
		//Returns everything up to closing tag or 
		//to first < if no closing tag found
		private string GetTagByName  
			(string strTagName, string strSource)
		{
			string strPatternTag 
				=	GetExpressionForTagContents(strTagName);
			string strPatternTagNoClose 
				= "<" + strTagName + @"(>|\s+[^>]*>)[^<]";
			RegexOptions opts 
				= RegexOptions.IgnoreCase | RegexOptions.Singleline;
			Match m;
			string strGetTagByName;

			m = System.Text.RegularExpressions.Regex.Match
				(strSource, strPatternTag, opts);
			if (m.Value == "")
			{
				m = System.Text.RegularExpressions.Regex.Match
					(strSource, strPatternTagNoClose, opts);
				if (m == null)
					strGetTagByName = strSource;
				else
					strGetTagByName = m.Value;
			}
			else
				strGetTagByName = m.Value;
			return(strGetTagByName);
		}

		//StripComments: Return Source minus comments
		private string StripComments(string strSource)
		{
			Regex r 
				= new Regex(GetExpressionForTagContents("!"));
			return( r.Replace(strSource, ""));
		}

		//ISOtoASCII: Convert ISO Characters to ASCII
		private string ISOtoASCII(string strText)
		{
		string[] strFrom = new string[131];
		string[] strTo = new string[131];
		strFrom[1] = "&Agrave;" ; strTo[1] = "À" ; //capital A, grave accent       
		strFrom[2] = "&agrave;" ; strTo[2] = "à" ; //small a, grave accent        
		strFrom[3] = "&Aacute;" ; strTo[3] = "Á" ; //capital A, acute accent      
		strFrom[4] = "&aacute;" ; strTo[4] = "á" ; //small a, acute accent        
		strFrom[5] = "&Acirc;" ; strTo[5] = "Â" ; //capital A, circumflex        
		strFrom[6] = "&acirc;" ; strTo[6] = "â" ; //small a, circumflex          
		strFrom[7] = "&Atilde;" ; strTo[7] = "Ã" ; //capital A, tilde             
		strFrom[8] = "&atilde;" ; strTo[8] = "ã" ; //small a, tilde               
		strFrom[9] = "&Auml;" ; strTo[9] = "Ä" ; //capital A, diæresis/umlaut   
		strFrom[10] = "&auml;" ; strTo[10] = "ä" ; //small a, diæresis/umlaut     
		strFrom[11] = "&Aring;" ; strTo[11] = "Å" ; //capital A, ring              
		strFrom[12] = "&aring;" ; strTo[12] = "å" ; //small a, ring                
		strFrom[13] = "&AElig;" ; strTo[13] = "Æ" ; //capital AE ligature          
		strFrom[14] = "&aelig;" ; strTo[14] = "æ" ; //small ae ligature            
		strFrom[15] = "&Ccedil;" ; strTo[15] = "Ç" ; //capital C, cedilla           
		strFrom[16] = "&ccedil;" ; strTo[16] = "ç" ; //small c, cedilla             
		strFrom[17] = "&Egrave;" ; strTo[17] = "È" ; //capital E, grave accent      
		strFrom[18] = "&egrave;" ; strTo[18] = "è" ; //small e, grave accent        
		strFrom[19] = "&Eacute;" ; strTo[19] = "É" ; //capital E, acute accent      
		strFrom[20] = "&eacute;" ; strTo[20] = "é" ; //small e, acute accent        
		strFrom[21] = "&Ecirc;" ; strTo[21] = "Ê" ; //capital E, circumflex        
		strFrom[22] = "&ecirc;" ; strTo[22] = "ê" ; //small e, circumflex          
		strFrom[23] = "&Euml;" ; strTo[23] = "Ë" ; //capital E, diæresis/umlaut   
		strFrom[24] = "&euml;" ; strTo[24] = "ë" ; //small e, diæresis/umlaut     
		strFrom[25] = "&Igrave;" ; strTo[25] = "Ì" ; //capital I, grave accent      
		strFrom[26] = "&igrave;" ; strTo[26] = "ì" ; //small i, grave accent        
		strFrom[27] = "&Iacute;" ; strTo[27] = "Í" ; //capital I, acute accent      
		strFrom[28] = "&iacute;" ; strTo[28] = "í" ; //small i, acute accent        
		strFrom[29] = "&Icirc;" ; strTo[29] = "Î" ; //capital I, circumflex        
		strFrom[30] = "&icirc;" ; strTo[30] = "î" ; //small i, circumflex          
		strFrom[31] = "&Iuml;" ; strTo[31] = "Ï" ; //capital I, diæresis/umlaut   
		strFrom[32] = "&iuml;" ; strTo[32] = "ï" ; //small i, diæresis/umlaut  
		strFrom[33] = "&ETH;" ; strTo[33] = "Ð" ; //capital Eth, Icelandic
		strFrom[34] = "&eth;" ; strTo[34] = "ð" ; //small eth, Icelandic
		strFrom[35] = "&Ntilde;" ; strTo[35] = "Ñ" ; //capital N, tilde        
		strFrom[36] = "&ntilde;" ; strTo[36] = "ñ" ; //small n, tilde               
		strFrom[37] = "&Ograve;" ; strTo[37] = "Ò" ; //capital O, grave accent      
		strFrom[38] = "&ograve;" ; strTo[38] = "ò" ; //small o, grave accent             
		strFrom[39] = "&Oacute;" ; strTo[39] = "Ó" ; //capital O, acute accent      
		strFrom[40] = "&oacute;" ; strTo[40] = "ó" ; //small o, acute accent        
		strFrom[41] = "&Ocirc;" ; strTo[41] = "Ô" ; //capital O, circumflex   
		strFrom[42] = "&ocirc;" ; strTo[42] = "ô" ; //small o, circumflex            
		strFrom[43] = "&Otilde;" ; strTo[43] = "Õ" ; //capital O, tilde             
		strFrom[44] = "&otilde;" ; strTo[44] = "õ" ; //small o, tilde               
		strFrom[45] = "&Ouml;" ; strTo[45] = "Ö" ; //capital O, diæresis/umlaut 
		strFrom[46] = "&ouml;" ; strTo[46] = "ö" ; //small o, diæresis/umlaut   
		strFrom[47] = "&Oslash;" ; strTo[47] = "Ø" ; //capital O, slash                   
		strFrom[48] = "&oslash;" ; strTo[48] = "ø" ; //small o, slash          
		strFrom[49] = "&Ugrave;" ; strTo[49] = "Ù" ; //capital U, grave accent           
		strFrom[50] = "&ugrave;" ; strTo[50] = "ù" ; //small u, grave accent        
		strFrom[51] = "&Uacute;" ; strTo[51] = "Ú" ; //capital U, acute accent      
		strFrom[52] = "&uacute;" ; strTo[52] = "ú" ; //small u, acute accent        
		strFrom[53] = "&Ucirc;" ; strTo[53] = "Û" ; //capital U, circumflex          
		strFrom[54] = "&ucirc;" ; strTo[54] = "û" ; //small u, circumflex            
		strFrom[55] = "&Uuml;" ; strTo[55] = "Ü" ; //capital U, diæresis/umlaut 
		strFrom[56] = "&uuml;" ; strTo[56] = "ü" ; //small u, diæresis/umlaut      
		strFrom[57] = "&Yacute;" ; strTo[57] = "Ý" ; //capital Y, acute accent      
		strFrom[58] = "&yacute;" ; strTo[58] = "ý" ; //small y, acute accent        
		strFrom[59] = "&THORN;" ; strTo[59] = "Þ" ; //capital Thorn, Icelandic       
		strFrom[60] = "&thorn;" ; strTo[60] = "þ" ; //small thorn, Icelandic         
		strFrom[61] = "&szlig;" ; strTo[61] = "ß" ; //small sharp s, German sz           
		strFrom[62] = "&yuml;" ; strTo[62] = "ÿ" ; //small y, diæresis/umlaut 
		strFrom[63] = "&nbsp;" ; strTo[63] = " " ; //non-breaking space          
		strFrom[64] = "&iexcl;" ; strTo[64] = "¡" ; //inverted exclamation mark   
		strFrom[65] = "&cent;" ; strTo[65] = "¢" ; //cent sign                   
		strFrom[66] = "&pound;" ; strTo[66] = "£" ; //pound sign                  
		strFrom[67] = "&curren;" ; strTo[67] = "¤" ; //general currency sign       
		strFrom[68] = "&yen;" ; strTo[68] = "¥" ; //yen sign                    
		strFrom[69] = "&brvbar;" ; strTo[69] = "¦" ; //broken [vertical] bar       
		strFrom[70] = "&sect;" ; strTo[70] = "§" ; //section sign                
		strFrom[71] = "&uml;" ; strTo[71] = "¨" ; //umlaut/dieresis             
		strFrom[72] = "&copy;" ; strTo[72] = "©" ; //copyright sign              
		strFrom[73] = "&ordf;" ; strTo[73] = "ª" ; //ordinal indicator, fem      
		strFrom[74] = "&laquo;" ; strTo[74] = "«" ; //angle quotation mark, left  
		strFrom[75] = "&not;" ; strTo[75] = "¬" ; //not sign                    
		strFrom[76] = "&shy;" ; strTo[76] = "­" ; //soft hyphen                 
		strFrom[77] = "&reg;" ; strTo[77] = "®" ; //registered sign             
		strFrom[78] = "&macr;" ; strTo[78] = "¯" ; //macron                      
		strFrom[79] = "&deg;" ; strTo[79] = "°" ; //degree sign                 
		strFrom[80] = "&#160;" ; strTo[80] = " " ; //non-breaking space          
		strFrom[81] = "&#161;" ; strTo[81] = "¡" ; //inverted exclamation mark   
		strFrom[82] = "&#162;" ; strTo[82] = "¢" ; //cent sign                   
		strFrom[83] = "&#163;" ; strTo[83] = "£" ; //pound sign                  
		strFrom[84] = "&#164;" ; strTo[84] = "¤" ; //general currency sign       
		strFrom[85] = "&#165;" ; strTo[85] = "¥" ; //yen sign                    
		strFrom[86] = "&#166;" ; strTo[86] = "¦" ; //broken [vertical] bar       
		strFrom[87] = "&#167;" ; strTo[87] = "§" ; //section sign                
		strFrom[88] = "&#168;" ; strTo[88] = "¨" ; //umlaut/dieresis             
		strFrom[89] = "&#169;" ; strTo[89] = "©" ; //copyright sign              
		strFrom[90] = "&#170;" ; strTo[90] = "ª" ; //ordinal indicator, fem      
		strFrom[91] = "&#171;" ; strTo[91] = "«" ; //angle quotation mark, left  
		strFrom[92] = "&#172;" ; strTo[92] = "¬" ; //not sign                    
		strFrom[93] = "&#173;" ; strTo[93] = "­" ; //soft hyphen                 
		strFrom[94] = "&#174;" ; strTo[94] = "®" ; //registered sign             
		strFrom[95] = "&#175;" ; strTo[95] = "¯" ; //macron                      
		strFrom[96] = "&#176;" ; strTo[96] = "°" ; //degree sign                 
		strFrom[97] = "&plusmn;" ; strTo[97] = "±" ; //plus-or-minus sign          
		strFrom[98] = "&sup2;" ; strTo[98] = "²" ; //superscript two          
		strFrom[99] = "&sup3;" ; strTo[99] = "³" ; //superscript three        
		strFrom[100] = "&acute;" ; strTo[100] = "´" ; //acute accent             
		strFrom[101] = "&micro;" ; strTo[101] = "µ" ; //micro sign                
		strFrom[102] = "&para;" ; strTo[102] = "¶" ; //pilcrow [paragraph sign] 
		strFrom[103] = "&middot;" ; strTo[103] = "·" ; //middle dot               
		strFrom[104] = "&cedil;" ; strTo[104] = "¸" ; //cedilla                  
		strFrom[105] = "&sup1;" ; strTo[105] = "¹" ; //superscript one          
		strFrom[106] = "&ordm;" ; strTo[106] = "º" ; //ordinal indicator, male  
		strFrom[107] = "&raquo;" ; strTo[107] = "»" ; //angle quotation mark, right   
		strFrom[108] = "&frac14;" ; strTo[108] = "¼" ; //fraction one-quarter          
		strFrom[109] = "&frac12;" ; strTo[109] = "½" ; //fraction one-half             
		strFrom[110] = "&frac34;" ; strTo[110] = "¾" ; //fraction three-quarters       
		strFrom[111] = "&iquest;" ; strTo[111] = "¿" ; //inverted question mark        
		strFrom[112] = "&times;" ; strTo[112] = "×" ; //multiply sign                 
		strFrom[113] = "&div;" ; strTo[113] = "÷" ; //division sign             
		strFrom[114] = "&#177;" ; strTo[114] = "±" ; //plus-or-minus sign          
		strFrom[115] = "&#178;" ; strTo[115] = "²" ; //superscript two          
		strFrom[116] = "&#179;" ; strTo[116] = "³" ; //superscript three        
		strFrom[117] = "&#180;" ; strTo[117] = "´" ; //acute accent             
		strFrom[118] = "&#181;" ; strTo[118] = "µ" ; //micro sign                
		strFrom[119] = "&#182;" ; strTo[119] = "¶" ; //pilcrow [paragraph sign] 
		strFrom[120] = "&#183;" ; strTo[120] = "·" ; //middle dot               
		strFrom[121] = "&#184;" ; strTo[121] = "¸" ; //cedilla                  
		strFrom[122] = "&#185;" ; strTo[122] = "¹" ; //superscript one          
		strFrom[123] = "&#186;" ; strTo[123] = "º" ; //ordinal indicator, male  
		strFrom[124] = "&#187;" ; strTo[124] = "»" ; //angle quotation mark, right   
		strFrom[125] = "&#188;" ; strTo[125] = "¼" ; //fraction one-quarter          
		strFrom[126] = "&#189;" ; strTo[126] = "½" ; //fraction one-half             
		strFrom[127] = "&#190;" ; strTo[127] = "¾" ; //fraction three-quarters       
		strFrom[128] = "&#191;" ; strTo[128] = "¿" ; //inverted question mark        
		strFrom[129] = "&#215;" ; strTo[129] = "×" ; //multiply sign                 
		strFrom[130] = "&#247;" ; strTo[130] = "÷" ; //division sign             

		int i;
		for(i = 1; i < strFrom.Length; i++)
	    {
		  strText = Regex.Replace(strText, strFrom[i], strTo[i],
			  RegexOptions.IgnoreCase | RegexOptions.Singleline);
		}
		return(strText);
      }
	}
}