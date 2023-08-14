using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DiplomPractice
{
    public class HuffmanTreeNode
    {
        public HuffmanTreeNode Parent; 
        public HuffmanTreeNode[] Children = new HuffmanTreeNode[2];
        public int Frequency = 0;
        public string Value = string.Empty;

        public HuffmanTreeNode(HuffmanTreeNode parent)
        {
            Parent = parent;
            Children = new HuffmanTreeNode[2];
        }
    }
    public class HuffmanTree
    {
        private Dictionary<string, int> heap;
        private List<HuffmanTreeNode> branches;
        private HuffmanTreeNode tree;

        public HuffmanTree()
        {
            heap = new Dictionary<string, int>();
            branches = new List<HuffmanTreeNode>();
            tree = new HuffmanTreeNode(null);
        }

        public string HuffmanCodeEncode(string value)
        {
            AddStringToHeap(value);
            tree = GetHuffmanTree();

            HashSet<string> letters = new HashSet<string>();
            for (int i = 0; i < value.Length; i++)
            {
                letters.Add(value[i].ToString());
            }

            string result = string.Empty;
            RecursionSearch();

            for (int i = 0; i < value.Length; i++)
            {
                if (kvp.ContainsKey(value[i].ToString()))
                {
                    result += kvp[value[i].ToString()] + " ";
                }
            }
            return string.Join(Environment.NewLine, kvp.Select(a => $"{a.Key} {a.Value}")) + '\n' + result;
        }
        private void AddStringToHeap(string value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                string str = value[i].ToString();
                if (!this.heap.ContainsKey(str))
                {
                    this.heap.Add(str, 1);
                    continue;
                }
                heap[str] += 1;
            }
            heap = heap.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }
        private HuffmanTreeNode GetHuffmanTree()
        {
            int i = 0;
            while (heap.Count != 1)
            {
                HuffmanTreeNode parent = new HuffmanTreeNode(null);

                HuffmanTreeNode left = new HuffmanTreeNode(parent);
                left = GetInternalNode(left, 0);

                HuffmanTreeNode rigth = new HuffmanTreeNode(parent);
                rigth = GetInternalNode(rigth, 1);

                parent.Value = "internal node" + i.ToString();
                parent.Frequency = left.Frequency + rigth.Frequency;

                parent.Children[0] = left;
                parent.Children[1] = rigth;

                branches.Add(parent);

                heap.Add(parent.Value, parent.Frequency);
                heap.Remove(heap.First().Key);
                heap.Remove(heap.First().Key);

                heap = heap.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                i++;
            }
            return branches.Last();
        }
        private HuffmanTreeNode GetInternalNode(HuffmanTreeNode child, int ind)
        {
            if (heap.Keys.ElementAt(ind).Length < 2)
            {
                child.Value = heap.Keys.ElementAt(ind);
                child.Frequency = heap.Values.ElementAt(ind);
                return child;
            }

            child.Frequency = heap.Values.ElementAt(ind);
            child.Value = heap.Keys.ElementAt(ind);

            foreach (var node in branches)
            {
                if (node.Frequency == child.Frequency && node.Value == child.Value)
                {
                    child = node;
                    break;
                }
            }
            return child;
        }

        public Dictionary<string, string> kvp = new Dictionary<string, string>();
        private void RecursionSearch()
        {
            string acc = string.Empty;
            RecursionSearchStart(tree, acc);
        }
        private void RecursionSearchStart(HuffmanTreeNode root, string acc)
        {
            if (root.Children[0] == null && root.Children[1] == null)
            {
                if (!kvp.ContainsKey(root.Value))
                {
                    kvp.Add(root.Value, acc);
                }
                acc = string.Empty;
                return;
            }
            else
            {
                if (root.Children[0] != null)
                {
                    RecursionSearchStart(root.Children[0], acc + "0");
                }
                if (root.Children[1] != null)
                {
                    RecursionSearchStart(root.Children[1], acc + "1");
                }
            }
        }

        public string HuffmanCodeDecode(string value)
        {
            var values = value.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            var codeWords = values[values.Length - 1].Split(' ');

            Dictionary<string, string> dic = new Dictionary<string, string>();
            for (int i = 0; i < values.Length - 1; i++)
            {
                var CharAndCode = values[i].Split(' ', '\n');
                if (CharAndCode[0] == "") CharAndCode[0] = " ";

                var character = CharAndCode.First();
                var code = CharAndCode.Last();
                dic.Add(code, character);
            }

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < codeWords.Length; i++)
            {
                if (dic.ContainsKey(codeWords[i]))
                {
                    result.Append(dic[codeWords[i]]);
                }
            }
            return result.ToString();
        }
    }
}
