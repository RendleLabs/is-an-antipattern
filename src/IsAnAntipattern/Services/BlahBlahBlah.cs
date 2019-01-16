using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using IsAnAntipattern.Markov;

namespace IsAnAntipattern.Services
{
    public class Blah
    {
        public string Text { get; set; }
        public string ImagePath { get; set; }
        public string UnsplashLink { get; set; }
    }
    public class BlahBlahBlah : IBlahBlahBlah
    {
        private readonly MarkovChain<string> _chain = CreateChain();
        
        public Blah GenerateParagraphs(string thing, int minSentences, int maxSentences, int paragraphs)
        {
            var builder = new StringBuilder();
            if (string.IsNullOrWhiteSpace(thing)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(thing));
            int hash = Hash(thing);
            
            var random = new Random(hash);
            var image = Images.List[random.Next(Images.List.Length)];

            for (int i = 0; i < paragraphs; i++)
            {
                builder.Append("<p>");
                int sentences = random.Next(minSentences, maxSentences);
                for (int j = 0; j < sentences; j++)
                {
                    builder.Append(string.Join(' ', _chain.Chain(random)));
                    builder.Append(' ');
                }

                builder.Append("</p>");
            }
            

            return new Blah
            {
                Text = builder.Replace("{thing}", thing).ToString(),
                ImagePath = image.Path,
                UnsplashLink = image.Unsplash
            };
        }

        private int Hash(string thing)
        {
            long hash = 0;
            var count = Encoding.UTF8.GetByteCount(thing);
            var bytes = ArrayPool<byte>.Shared.Rent(count + 4);
            var span = bytes.AsSpan();
            try
            {
                Encoding.UTF8.GetBytes(thing.AsSpan(), span);
                for (int i = 0; i < count; i+=4)
                {
                    hash += BitConverter.ToInt32(span.Slice(i, 4));
                }
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(bytes);
            }

            return (int) (hash & int.MaxValue);
        }

        private static MarkovChain<string> CreateChain()
        {
            var chain = new MarkovChain<string>(1);

            foreach (var line in SourceData.Lines)
            {
                chain.Add(line, 1);
            }

            return chain;
        }
    }

    public class RandomImage
    {
        public RandomImage(string path, string id, string name)
        {
            Path = path;
            Unsplash = UnsplashLink(id, name);
        }
        public string Path { get; }
        public string Unsplash { get; }

        private string UnsplashLink(string id, string name)
        {
            return $@"<a class=""unsplash-link""
href=""https://unsplash.com/@{id}?utm_medium=referral&amp;utm_campaign=photographer-credit&amp;utm_content=creditBadge""
target=""_blank"" rel=""noopener noreferrer""
title=""Download free do whatever you want high-resolution photos from {name}"">
<span style=""display:inline-block;padding:2px 3px""><svg xmlns=""http://www.w3.org/2000/svg""
style=""height:12px;width:auto;position:relative;vertical-align:middle;top:-2px;fill:white"" viewBox=""0 0 32 32"">
<title>unsplash-logo</title><path d=""M10 9V0h12v9H10zm12 5h10v18H0V14h10v9h12v-9z""></path></svg></span>
<span style=""display:inline-block;padding:2px 3px"">{name}</span></a>";
        }
    }
}