using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestChain_Length_To_Reach_TargetWord
{
    class Program
    {
        static void Main(string[] args)
        {
            //string start = "toon";//"hit";
            //string end = "plea";//"cog";
            //HashSet<string> dict = new HashSet<string> { "poon", "plee", "same", "poie", "plea", "plie", "poin" }; //{ "hot", "dot", "dog", "lot", "log" };

            string start = "hit";
            string end = "cog";
            HashSet<string> dict = new HashSet<string> { "hot", "dot", "dog", "lot", "log" };


            //findLadders(start, end, dict);
            ladderLength(start, end, dict);
        }

        static public List<List<string>> findLadders(string start, string end, HashSet<string> dict)
        {
            List<List<string>> result = new List<List<string>>();

            Queue<WordNode> queue = new Queue<WordNode>();
            queue.Enqueue(new WordNode(start, 1, null));

            dict.Add(end);

            int minStep = 0;

            HashSet<string> visited = new HashSet<string>();
            HashSet<string> unvisited = new HashSet<string>();
            unvisited.UnionWith(dict);

            int preNumSteps = 0;

            while (queue.Any())
            {
                WordNode top = queue.Dequeue();
                string word = top.word;
                int currNumSteps = top.numSteps;

                if (word.Equals(end))
                {
                    if (minStep == 0)
                    {
                        minStep = top.numSteps;
                    }

                    if (top.numSteps == minStep && minStep != 0)
                    {
                        //nothing
                        List<string> t = new List<string>();
                        t.Add(top.word);
                        while (top.pre != null)
                        {
                            t.Insert(0, top.pre.word);
                            top = top.pre;
                        }
                        result.Add(t);
                        continue;
                    }

                }

                if (preNumSteps < currNumSteps)
                {
                    unvisited.IntersectWith(visited);
                }

                preNumSteps = currNumSteps;

                char[] arr = word.ToCharArray();
                for (int i = 0; i < arr.Length; i++)
                {
                    for (char c = 'a'; c <= 'z'; c++)
                    {
                        char temp = arr[i];
                        if (arr[i] != c)
                        {
                            arr[i] = c;
                        }

                        string newWord = new string(arr);
                        if (unvisited.Contains(newWord))
                        {
                            queue.Enqueue(new WordNode(newWord, top.numSteps + 1, top));
                            visited.Add(newWord);
                        }

                        arr[i] = temp;
                    }
                }


            }

            return result;
        }

        static public int ladderLength(string beginWord, string endWord, HashSet<string> wordDict)
        {
            Console.WriteLine("Transition words are: ");
            Console.Write(beginWord + "  ");

            HashSet<string> reached = new HashSet<string>();
            reached.Add(beginWord);
            wordDict.Add(endWord);
            int distance = 1;
            while (!reached.Contains(endWord))
            {
                HashSet<string> toAdd = new HashSet<string>();
                foreach (string each in reached)
                {
                    for (int i = 0; i < each.Length; i++)
                    {
                        char[] chars = each.ToCharArray();
                        for (char ch = 'a'; ch <= 'z'; ch++)
                        {
                            chars[i] = ch;
                            string word = new string(chars);
                            if (wordDict.Contains(word))
                            {
                                toAdd.Add(word);
                                wordDict.Remove(word);
                            }
                        }
                    }
                }
                Console.Write(toAdd.First() + "  ");
                distance++;
                if (toAdd.Count() == 0) return 0;
                reached = toAdd;
            }
            Console.WriteLine();
            Console.WriteLine("Distance is: " + distance);
            return distance;
        }
    }

    class WordNode
    {
        public string word;
        public int numSteps;
        public WordNode pre;

        public WordNode(string word, int numSteps, WordNode pre)
        {
            this.word = word;
            this.numSteps = numSteps;
            this.pre = pre;
        }
    }
}

//https://discuss.leetcode.com/topic/20965/java-solution-using-dijkstra-s-algorithm-with-explanation

//http://www.programcreek.com/2012/12/leetcode-word-ladder/
//http://www.programcreek.com/2014/06/leetcode-word-ladder-ii-java/
//http://www.geeksforgeeks.org/length-of-shortest-chain-to-reach-a-target-word/


//Average Difficulty : 2.9/5.0
//Based on 20 vote(s)