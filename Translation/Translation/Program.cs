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
        integer,
        floatingNumber,
        identifier,
        whiteSpace,
        newLine
    }

    public class Program
    {
        private int _counter;
        private SymbolType _lecsicalSymbolType;
        private string _line;
        private char _symbol;
        private StringBuilder _identifier;
        private StringBuilder _integer;
        private StringBuilder _floatingNumber;


        private void ReadFromFile(string filePath)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(filePath);
            while ((_line = file.ReadLine()) != null)
            {
                AnalizeLecsicalSymbolType();
            }

            file.Close();
        }

        //private void AnalizeLine()
        //{
        //    foreach (char _symbol in _line)
        //    {
        //        AnalizeLecsicalSymbolType(); 
        //    }
        //}
        //private void GetInteger()
        //{
        //    _integer = new StringBuilder();
        //    _integer.Append(_symbol);

        //    if (++_counter <= _line.Length - 1)
        //    {
        //        _symbol = _line[_counter];
        //        if (char.IsDigit(_symbol))
        //        {
        //            while (char.IsDigit(_symbol))
        //            {
        //                _integer.Append(_symbol);
        //                _counter++;
        //                _symbol = _line[_counter];
        //            }
        //        }
        //        else
        //            _symbol = _line[_counter--];
        //    }
            
        //}

        private void GetIdentifier()
        {
            _identifier = new StringBuilder();
            _identifier.Append(_symbol);

            if (++_counter <= _line.Length - 1)
            {
                _symbol = _line[_counter];
                if (char.IsLetter(_symbol) || char.IsDigit(_symbol))
                {
                    while (char.IsLetter(_symbol) || char.IsDigit(_symbol))
                    {
                        _identifier.Append(_symbol);
                        _counter++;
                        _symbol = _line[_counter];
                    }
                }
                _symbol = _line[_counter--];
            }
            
        }


        private void AnalizeLecsicalSymbolType()
        {
            for (_counter = 0; _counter < _line.Length; _counter++)
            {
                _symbol = _line[_counter];

                if (_symbol == '(')
                {
                    _lecsicalSymbolType = SymbolType.leftParenthesis;
                    Console.WriteLine("{0}: {1}", _lecsicalSymbolType, _symbol);
                }
                else if (_symbol == ')')
                {
                    _lecsicalSymbolType = SymbolType.rightParenthesis;
                    Console.WriteLine("{0}: {1}", _lecsicalSymbolType, _symbol);
                }
                else if (_symbol == '*' || _symbol == '+' || _symbol == '/' || _symbol == '-')
                {
                    _lecsicalSymbolType = SymbolType.operation;
                    Console.WriteLine("{0}: {1}", _lecsicalSymbolType, _symbol);
                }
                else if (char.IsWhiteSpace(_symbol))
                {
                    _lecsicalSymbolType = SymbolType.whiteSpace;
                    Console.WriteLine("{0}: {1}", _lecsicalSymbolType, _symbol);
                }
                else if (char.IsDigit(_symbol))
                {
                    _lecsicalSymbolType = SymbolType.integer;
                    GetIdentifier();
                    Console.WriteLine("{0}: {1}", _lecsicalSymbolType, _identifier);
                }
                else if (char.IsLetter(_symbol))
                {
                    _lecsicalSymbolType = SymbolType.identifier;
                    GetIdentifier();
                    Console.WriteLine("{0}: {1}", _lecsicalSymbolType, _identifier);
                }


            }
        }

        static void Main(string[] args)
        {
            Program prog = new Program();
            prog.ReadFromFile("new.txt");
        }
    }
}
