using System;
using System.Text.RegularExpressions;
using System.Data;
using System.Collections;
using System.IO;


namespace HttpUtils
{
	/// <summary>
	/// Google Translation Utility Class (c)Peter A. Bromberg 2005
	/// </summary>
	
	public  enum LangPair 
	{
	EnglishToGerman ,	
	EnglishToSpanish ,	
	EnglishToFrench ,	
	EnglishToItalian ,	
	EnglishToPortuguese,	
	EnglishToJapanese,	
	EnglishToKorean,	
	EnglishToChineseSimplified,	
	GermanToEnglish ,	
	GermanToFrench,	
	SpanishToEnglish,	
	FrenchToEnglish,	
	FrenchToGerman ,	
	ItalianToEnglish,	
	PortugueseToEnglish,	
	JapaneseToEnglish,	
	KoreanToEnglish,	
	ChineseSimplifiedToEnglish
	}
	

	public class TranslateUtil
	{
		private TranslateUtil()
		{
		}

		public static ArrayList  GetLangPairs()
		{
          ArrayList al = new ArrayList();
		Array vals=Enum.GetValues(typeof(LangPair)) ;
		al.Add("Please Select");
		 foreach (object o in vals)
			 al.Add(o.ToString());
			return al;
		}
		
		public static string GetTranslatedText(string textToTranslate , LangPair langPair)
		{		
			string strLangPair=String.Empty ;

			switch(langPair)
			{
				case (LangPair.ChineseSimplifiedToEnglish):
					strLangPair = "zh-CN%7Cen";
					break;
				case (LangPair.EnglishToChineseSimplified):
					strLangPair = "en%7Czh-CN";
					break;
				case (LangPair.EnglishToFrench):
					strLangPair = "en%7Cfr";
					break;
                case (LangPair.EnglishToGerman):
					strLangPair = "en%7Cde";
					break;
				case (LangPair.EnglishToItalian):
					strLangPair = "en%7Cit";
					break;
				case (LangPair.EnglishToJapanese):
					strLangPair = "en%7Cja";
					break;
				case (LangPair.EnglishToKorean):
					strLangPair = "en%7Cko";
					break;
				case (LangPair.EnglishToPortuguese):
					strLangPair = "en%7Cpt";
					break;
				case (LangPair.EnglishToSpanish):
					strLangPair = "en%7Ces";
					break;
				case (LangPair.FrenchToEnglish):
					strLangPair = "fr%7Cen";
					break;
				case (LangPair.FrenchToGerman):
					strLangPair = "fr%7Cde";
					break;
				case (LangPair.GermanToEnglish):
					strLangPair = "de%7Cen";
					break;
				case (LangPair.GermanToFrench):
					strLangPair = "de%7Cfr";
					break;
				case (LangPair.ItalianToEnglish):
					strLangPair = "it%7Cen";
					break;
				case (LangPair.JapaneseToEnglish):
					strLangPair = "ja%7Cen";
					break;
				case (LangPair.KoreanToEnglish):
					strLangPair = "ko%7Cen";
					break;
				case (LangPair.PortugueseToEnglish):
					strLangPair ="pt%7Cen";
					break;
				case (LangPair.SpanishToEnglish):
					strLangPair = "es%7Cen";
					break;
				default:
					strLangPair="en%7Cde";
					break;
			}

			WebWagon.HTMLPage ww = new WebWagon.HTMLPage();
			ww.LoadSource("http://translate.google.com/translate_t?text=" +textToTranslate+"&langpair=" +strLangPair);		 
			
			string[] stuff=	ww.GetTagsByName("div");
			Regex findData = new Regex(@"<(?<tag>.*).*>(?<text>.*)</\k<tag>>");
			Match foundData = findData.Match(stuff[0]);
			return foundData.Groups["text"].Value ;
		}
	}
}
