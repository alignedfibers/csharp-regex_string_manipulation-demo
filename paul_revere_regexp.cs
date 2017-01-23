using System.Text.RegularExpressions;
using System;

namespace chap8.regular_exp
{
	class paulRevereParsing
	{
		private static string thePoem = "Listen my children and you shall hear Of the midnight ride of Paul Revere, On the eighteenth of April, in Seventy-five; Hardly a man is now alive Who remembers that famous day and year. He said to his friend, \"If the British march By land or sea from the town to-night, Hang a lantern aloft in the belfry arch Of the North Church tower as a signal light,-- One if by land, and two if by sea; And I on the opposite shore will be, Ready to ride and spread the alarm Through every Middlesex village and farm, For the country folk to be up and to arm.\" Then he said \"Good-night!\" and with muffled oar Silently rowed to the Charlestown shore, Just as the moon rose over the bay, Where swinging wide at her moorings lay The Somerset, British man-of-war; A phantom ship, with each mast and spar Across the moon like a prison bar, And a huge black hulk, that was magnified By its own reflection in the tide.";
		
		public static void Main(){
		Console.WriteLine("");
		Console.WriteLine(thePoem);
		Console.WriteLine("");
		findEndDe();
		findMiddleUr();
		findAnywhereRe();
		findIn();
		findLastChar();
		}
		
		static void findEndDe(){
		    //Finds any word delimited by a space ending in de
			string pattern = @"\s\S*de\b";
			Console.WriteLine("Searching for words ending in \"de\"");
			
			MatchCollection matches = Regex.Matches(thePoem, pattern, RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);
			
			DisplayResults(matches);
			Console.WriteLine("");
		}
		static void findAnywhereRe(){
		    //Finds any word delimited by a space ending in de
			string pattern = @"\s\S*re\S*\s";
			Console.WriteLine("Searching for words with \"re\" anywhere");
			MatchCollection matches = Regex.Matches(thePoem, pattern, RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);
			
			DisplayResults(matches);
			Console.WriteLine("");
		}
		static void findMiddleUr(){
		    //Finds any word delimited by a space ending in de
			string pattern = @"\s\S+ur\S+\s";
			Console.WriteLine("Searching for words with \"ur\" in the middle");
			MatchCollection matches = Regex.Matches(thePoem, pattern, RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);
			
			DisplayResults(matches);
			Console.WriteLine("");
		}
		static void findIn(){
		    //Finds any word delimited by a space ending in de
			string pattern = @"\s\S*(in)+\S*\s";
			Console.WriteLine("Searching for words with \"in\" anywhere one or more times");
			MatchCollection matches = Regex.Matches(thePoem, pattern, RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);
			
			DisplayResults(matches);
			Console.WriteLine("");
		}
		static void findLastChar(){
		    //Finds any word delimited by a space ending in de
			string pattern = @"\s\S*(b | a | r)\b";
			Console.WriteLine("Searching for words with \"b | a | r\" as the last character");
			MatchCollection matches = Regex.Matches(thePoem, pattern, RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);
			
			DisplayResults(matches);
			Console.WriteLine("");
		}
		
		
		static void DisplayResults(MatchCollection matches){
			int count = 0;
			foreach(Match nextMatch in matches){
				int index = nextMatch.Index;
				string result =  nextMatch.ToString();
				
				int charsBefore = (index<5) ? index : 0;
				int fromEnd = thePoem.Length - index - result.Length;
				
				int charsAfter = (fromEnd<5) ? fromEnd : 0;
				
				int charsToDisplay = charsBefore + charsAfter + result.Length;
				count++;
				Console.WriteLine("Index: {0}, \t{2} word found: {1} ",index,result,numero.AddGramaticAbrv(count));
			
			}
			
		}
	}
	
	class numero 
	{
		public static string AddGramaticAbrv(int num){
		char testChar1;
		char testChar2;
		string strNum = num.ToString();
		if(strNum.Length>1){
		testChar1 = char.Parse(strNum.Substring(strNum.Length - 2, 1));
		testChar2 = char.Parse(strNum.Substring(strNum.Length - 1, 1));
		Console.WriteLine(testChar1);
		}else{
		testChar1 = char.Parse("0");
		testChar2 = char.Parse(strNum.Substring(strNum.Length - 1, 1));
		}
		
		string returnString = null;
		if(testChar1 == char.Parse("1")){
		Console.WriteLine("char1 == 1");
			if(testChar2 != char.Parse("2"))
				returnString = strNum+"nth";
			if(testChar2 == char.Parse("2"))
				returnString = strNum+"th";							
		}else{
			if(testChar2 > char.Parse("3"))
				returnString = strNum+"th";	
			if(testChar2 == char.Parse("1"))
				returnString = strNum+"st";	
			if(testChar2 == char.Parse("2"))
				returnString = strNum+"nd";
			if(testChar2 == char.Parse("3"))
				returnString = strNum+"rd";
		}
			return returnString;
		}
	}
		
}