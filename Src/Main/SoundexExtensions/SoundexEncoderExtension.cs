using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Server;

namespace USC.GISResearchLab.Common.Core.SqlExtensions.SoundexExtensions
{
    public class SoundexEncoderExtension
    {
        public SoundexEncoderExtension()
        {

        }

        [SqlFunction(DataAccess = DataAccessKind.None)]
        public static string ComputeEncodingNew(string word)
        {
            return ComputeEncodingNew1(word, 4);
        }

        [SqlFunction(DataAccess = DataAccessKind.None)]

        public static string ComputeEncodingNew1(string word, int length)
        {
            string value = "";

            if (!String.IsNullOrEmpty(word))
            {
                int size = word.Length;

                word = word.ToUpper();
                char[] characters = word.ToCharArray();

                //create a buffer to store the array of characters
                StringBuilder buffer = new StringBuilder();

                int current = 0;
                int previous = 0;
                buffer.Length = 0;

                char previousChar = characters[0];
                char currentChar;

                //Append the first character to the buffer
                buffer.Append(characters[0]);
                switch (previousChar)
                {

                    case 'B':
                        previous = 1;
                        break;
                    case 'F':
                        previous = 1;
                        break;
                    case 'P':
                        previous = 1;
                        break;
                    case 'V':
                        previous = 1;
                        break;
                    case 'C':
                        previous = 2;
                        break;
                    case 'G':
                        previous = 2;
                        break;
                    case 'J':
                        previous = 2;
                        break;
                    case 'K':
                        previous = 2;
                        break;
                    case 'Q':
                        previous = 2;
                        break;
                    case 'S':
                        previous = 2;
                        break;
                    case 'X':
                        previous = 2;
                        break;
                    case 'Z':
                        previous = 2;
                        break;
                    case 'D':
                        previous = 3;
                        break;
                    case 'T':
                        previous = 3;
                        break;
                    case 'L':
                        previous = 4;
                        break;
                    case 'M':
                        previous = 5;
                        break;
                    case 'N':
                        previous = 5;
                        break;
                    case 'R':
                        previous = 6;
                        break;
                    case 'A':
                        previous = 7;
                        break;
                    case 'E':
                        previous = 7;
                        break;
                    case 'I':
                        previous = 7;
                        break;
                    case 'O':
                        previous = 7;
                        break;
                    case 'U':
                        previous = 7;
                        break;
                    case 'Y':
                        previous = 7;
                        break;
                    case 'H':
                        previous = 8;
                        break;
                    case 'W':
                        previous = 8;
                        break;

                }

                //start the loop to convert the other characters to numbers
                for (int i = 1; i < size; i++)
                {
                    current = 0;
                    currentChar = characters[i];

                    switch (currentChar)
                    {

                        case 'B':
                            current = 1;
                            break;
                        case 'F':
                            current = 1;
                            break;
                        case 'P':
                            current = 1;
                            break;
                        case 'V':
                            current = 1;
                            break;
                        case 'C':
                            current = 2;
                            break;
                        case 'G':
                            current = 2;
                            break;
                        case 'J':
                            current = 2;
                            break;
                        case 'K':
                            current = 2;
                            break;
                        case 'Q':
                            current = 2;
                            break;
                        case 'S':
                            current = 2;
                            break;
                        case 'X':
                            current = 2;
                            break;
                        case 'Z':
                            current = 2;
                            break;
                        case 'D':
                            current = 3;
                            break;
                        case 'T':
                            current = 3;
                            break;
                        case 'L':
                            current = 4;
                            break;
                        case 'M':
                            current = 5;
                            break;
                        case 'N':
                            current = 5;
                            break;
                        case 'R':
                            current = 6;
                            break;
                        case 'A':
                            current = 7;
                            break;
                        case 'E':
                            current = 7;
                            break;
                        case 'I':
                            current = 7;
                            break;
                        case 'O':
                            current = 7;
                            break;
                        case 'U':
                            current = 7;
                            break;
                        case 'Y':
                            current = 7;
                            break;
                        case 'H':
                            current = 8;
                            break;
                        case 'W':
                            current = 8;
                            break;

                    }


                    // drop vowels, w, and h
                    if (current != 0)
                    {
                        // drop double characters 'ss'
                        if (current != 8)
                        {
                            if (current != 7)
                            {
                                // drop double codes 'cs' -> 22
                                if (current != previous)
                                {
                                    buffer.Append(current);//Append the current code to the buffer
                                }
                            }

                            if (buffer.Length == length)
                                break;

                            previous = current;
                            previousChar = currentChar;

                        }
                    }



                }

                size = buffer.Length;

                if (size < length)
                {
                    buffer.Append('0', length - size);
                }

                value = buffer.ToString();
            }

            return value;
        }
    }
}
