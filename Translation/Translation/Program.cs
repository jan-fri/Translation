using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translation
{
    enum SymbolType
    {
        left_parenthesis,
        right_parenthesis,
        operation,
        integer,
        floating_number,
        identifier,
        whitespace,
        new_line
    }

    public class Program
    {
        private bool _error;
        private int _counter;
        private SymbolType _lecsicalSymbolType;
        private string _line;
        private char _symbol;
        private StringBuilder _number;

        private void ReadFromFile(string filePath)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(filePath);
            while ((_line = file.ReadLine()) != null)
            {
                string l = _line + ' ';
                _line = l;
                AnalizeLecsicalSymbolType();
            }

            file.Close();
        }

        private void CheckSymbol()
        {
            if (_symbol == '.' && _number.ToString().Contains('.'))
            {
                Console.WriteLine("Symbol not recognized, canceling translation");
                _error = true;
            }
        }
        private void GetNumber()
        {
            _number = new StringBuilder();
            _number.Append(_symbol);

            if (++_counter <= _line.Length - 1)
            {
                _symbol = _line[_counter];

                while (char.IsDigit(_symbol) || _symbol == '.')
                {
                    CheckSymbol();
                    if (_error == true)
                        break;

                    _number.Append(_symbol);
                    _counter++;
                    _symbol = _line[_counter];
                }

                _symbol = _line[_counter--];
            }

            if (!_error)
            {
                string id = _number.ToString();
                if (id.Contains('.'))
                    _lecsicalSymbolType = SymbolType.floating_number;

                Console.WriteLine("{0}: {1}", _lecsicalSymbolType, _number); 
            }

        }

        private void GetWord()
        {
            _number = new StringBuilder();
            _number.Append(_symbol);

            if (++_counter <= _line.Length - 1)
            {
                _symbol = _line[_counter];

                while (char.IsLetter(_symbol) || char.IsDigit(_symbol))
                {
                    _number.Append(_symbol);
                    _counter++;
                    _symbol = _line[_counter];
                }

                _symbol = _line[_counter--];
            }

            if (!_error)
            {
                string id = _number.ToString();
                if (id.Contains('.'))
                    _lecsicalSymbolType = SymbolType.floating_number;

                Console.WriteLine("{0}: {1}", _lecsicalSymbolType, _number);
            }

        }


        private void AnalizeLecsicalSymbolType()
        {
            for (_counter = 0; _counter < _line.Length; _counter++)
            {
                if (_error)
                    break;

                _symbol = _line[_counter];

                if (_symbol == '(')
                {
                    _lecsicalSymbolType = SymbolType.left_parenthesis;
                    Console.WriteLine("{0}: {1}", _lecsicalSymbolType, _symbol);
                }
                else if (_symbol == ')')
                {
                    _lecsicalSymbolType = SymbolType.right_parenthesis;
                    Console.WriteLine("{0}: {1}", _lecsicalSymbolType, _symbol);
                }
                else if (_symbol == '*' || _symbol == '+' || _symbol == '/' || _symbol == '-')
                {
                    _lecsicalSymbolType = SymbolType.operation;
                    Console.WriteLine("{0}: {1}", _lecsicalSymbolType, _symbol);
                }
                else if (char.IsDigit(_symbol))
                {
                    _lecsicalSymbolType = SymbolType.integer;
                    GetNumber();
                }
                else if (char.IsLetter(_symbol))
                {
                    _lecsicalSymbolType = SymbolType.identifier;
                    GetWord();
                }
                else if (char.IsWhiteSpace(_symbol))
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("Symbol not recognized, canceling translation");
                    break;
                }

            }
        }

        static void Main(string[] args)
        {
            Program prog = new Program();
            prog.ReadFromFile("new.txt");
            Console.ReadLine();
        }
    }
}
