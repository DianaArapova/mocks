using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using TagsCloudVisualization.TagReader.TagReader;

namespace TagsCloudVisualization.TagReader.TextParser
{
	public class EnglishTextParser : IParser
	{
		private readonly ITagReader tagReader;
		public EnglishTextParser(ITagReader tagReader)
		{
			this.tagReader = tagReader;
		}

		public IEnumerable<string> GetWordsFromLine(string line)
		{
			var regexForEnglishWord = new Regex(@"[A-Za-z']+");
			foreach (Match match in regexForEnglishWord.Matches(line))
				if (!(match is null))
					yield return match.Value;
		}

		public IEnumerable<string> Parse(string path)
		{
			return tagReader.Read(path).SelectMany(GetWordsFromLine);
		}
	}
}