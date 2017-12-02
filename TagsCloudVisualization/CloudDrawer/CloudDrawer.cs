﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace TagsCloudVisualization.CloudDrawer
{
	public class CloudDrawer : ICloudDrawer
	{
		private readonly Brush[] tagColor;
		private readonly string tagFontName;
		private Size imageSize;

		public CloudDrawer(Config config)
		{
			tagColor = config.TagColor;
			tagFontName = config.TagFontName;
			imageSize = config.ImageSize;
		}

		public Bitmap Draw(Dictionary<string, Rectangle> tagList)
		{
			var bitmap = new Bitmap(imageSize.Width, imageSize.Height);
			using (var gr = Graphics.FromImage(bitmap))
			{
				var random = new Random();
				foreach (var tag in tagList)
				{
					var index = random.Next(3);
					gr.DrawString(tag.Key, new Font(tagFontName, tag.Value.Height / 2), tagColor[index],
						tag.Value.Location);
				}
			}
			return bitmap;
		}
	}
}