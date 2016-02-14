using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translation
{
    enum SymbolType
    {
        leftParenthesis,
        rightParenthesis,
        operation,
        number,
        floatingNumber,
        identifier        
    }

    class Program
    {
        private SymbolType _lecsicalSymbolType;
        private string _line;
        private char _symbol;

        private void ReadFromFile(string filePath)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(filePath);
            while ((_line = file.ReadLine()) != null)
            {
                AnalizeLine();
            }

            file.Close();
        }
        
        private void AnalizeLine()
        {
            foreach (char _symbol in _line)
            {
                AnalizeLecsicalSymbolType(); 
            }
        }

        private void AnalizeLecsicalSymbolType()
        {
            switch (_symbol)
            {
                default:
            }
        }

        static void Main(string[] args)
        {
        }
    }
}
