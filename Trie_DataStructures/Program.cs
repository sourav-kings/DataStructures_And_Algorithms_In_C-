using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trie_DataStructures
{
    class Program
    {
        static TrieNode root = new TrieNode(' ');
        static void Main(string[] args)
        {
            //search("beach");
            insert("beach");
            Console.WriteLine("Search result : " + search("beach"));
            Console.WriteLine("Search result : " + search("beach2"));
        }

        /* Function to insert word */
        static void insert(String word)
        {
            if (search(word) == true)
                return;
            TrieNode current = root;
            foreach (char ch in word.ToCharArray())
            {
                TrieNode child = current.subNode(ch);
                if (child != null)
                    current = child;
                else
                {
                    current.childList.AddFirst(new TrieNode(ch));
                    current = current.subNode(ch);
                }
                current.count++;
            }
            current.isEnd = true;
        }
        /* Function to search for word */
        static bool search(string word)
        {
            TrieNode current = root;
            foreach (char ch in word.ToCharArray())
            {
                if (current.subNode(ch) == null)
                    return false;
                else
                    current = current.subNode(ch);
            }
            if (current.isEnd == true)
                return true;
            return false;
        }
    }

    class TrieNode
    {
        public char content;
        public bool isEnd;
        public int count;
        public LinkedList<TrieNode> childList;

        /* Constructor */
        public TrieNode(char c)
        {
            childList = new LinkedList<TrieNode>();
            isEnd = false;
            content = c;
            count = 0;
        }
        public TrieNode subNode(char c)
        {
            if (childList != null)
                foreach (TrieNode eachChild in childList)
                    if (eachChild.content == c)
                        return eachChild;
            return null;
        }
    }
}


//http://www.sanfoundry.com/java-program-implement-trie/
//https://www.toptal.com/java/the-trie-a-neglected-data-structure
//https://www.topcoder.com/community/data-science/data-science-tutorials/using-tries/

/*
 What makes the trie really perform well in these situations is that the cost of looking up a word or prefix is fixed 
 and dependent only on the number of characters in the word and not on the size of the vocabulary.
 */
