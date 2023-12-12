using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace SHA2_SHA3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string DecToBin(UInt64 b)
        {
            string a = "";
            while (b > 0)
            {
                a = (b % 2) + a;
                b /= 2;
            }
            return a;
        }

        private UInt64 BinToDec(string a)
        {
            UInt64 result = 0;
            int length = a.Length;
            int ex = length - 1;
            for (int i = 0; i < length; i++)
            {
                if (a[i] == '1')
                {
                    result += (UInt64)Math.Pow(2, ex);
                }
                ex--;
            }
            return result;
        }

        private string DecToHex(UInt64 b)
        {
            string hex = "";
            while (b > 0)
            {
                if ((b % 16) == 10)
                {
                    hex = "a" + hex;
                }
                else
                if ((b % 16) == 11)
                {
                    hex = "b" + hex;
                }
                else
                if ((b % 16) == 12)
                {
                    hex = "c" + hex;
                }
                else
                if ((b % 16) == 13)
                {
                    hex = "d" + hex;
                }
                else
                if ((b % 16) == 14)
                {
                    hex = "e" + hex;
                }
                else
                if ((b % 16) == 15)
                {
                    hex = "f" + hex;
                }
                else
                {
                    hex = (b % 16) + hex;
                }
                b /= 16;
            }
            return hex;
        }

        private string summary_binarynumber(string a, string b)
        {
            string result = "";
            int length = a.Length;
            string temp = "0";
            for (int i = length - 1; i >= 0; i--)
            {
                string sum = "";
                sum += a[i];
                sum += b[i];
                sum += temp;
                int count_one = 0;
                for (int j = 0; j < sum.Length; j++)
                {
                    if (sum[j] == '1')
                        count_one++;
                }
                if (count_one == 0)
                {
                    result = "0" + result;
                    temp = "0";
                }
                else
                if (count_one == 1)
                {
                    result = "1" + result;
                    temp = "0";
                }
                else
                if (count_one == 2)
                {
                    result = "0" + result;
                    temp = "1";
                }
                else
                {
                    result = "1" + result;
                    temp = "1";
                }
                if ((i == 0) && (count_one == 2))
                {
                    result = "1" + result;
                }
            }
            return result;
        }

        private int count_chunk(int length, int n)
        {
            int count = 0;
            while (length >= 0)
            {
                if (count < 1)
                {
                    length -= n;
                }
                else
                {
                    length -= (n + 64);
                }
                count++;
            }
            return count;
        }

        private string add_zero(string s, int l)
        {
            double en = (l + l) % (s.Length + l);
            for (int i = 0; i < en; i++)
                s = "0" + s;
            return s;
        }

        private string[] k = new string[64] {
            "01000010100010100010111110011000",
            "01110001001101110100010010010001",
            "10110101110000001111101111001111",
            "11101001101101011101101110100101",
            "00111001010101101100001001011011",
            "01011001111100010001000111110001",
            "10010010001111111000001010100100",
            "10101011000111000101111011010101",
            "11011000000001111010101010011000",
            "00010010100000110101101100000001",
            "00100100001100011000010110111110",
            "01010101000011000111110111000011",
            "01110010101111100101110101110100",
            "10000000110111101011000111111110",
            "10011011110111000000011010100111",
            "11000001100110111111000101110100",
            "11100100100110110110100111000001",
            "11101111101111100100011110000110",
            "00001111110000011001110111000110",
            "00100100000011001010000111001100",
            "00101101111010010010110001101111",
            "01001010011101001000010010101010",
            "01011100101100001010100111011100",
            "01110110111110011000100011011010",
            "10011000001111100101000101010010",
            "10101000001100011100011001101101",
            "10110000000000110010011111001000",
            "10111111010110010111111111000111",
            "11000110111000000000101111110011",
            "11010101101001111001000101000111",
            "00000110110010100110001101010001",
            "00010100001010010010100101100111",
            "00100111101101110000101010000101",
            "00101110000110110010000100111000",
            "01001101001011000110110111111100",
            "01010011001110000000110100010011",
            "01100101000010100111001101010100",
            "01110110011010100000101010111011",
            "10000001110000101100100100101110",
            "10010010011100100010110010000101",
            "10100010101111111110100010100001",
            "10101000000110100110011001001011",
            "11000010010010111000101101110000",
            "11000111011011000101000110100011",
            "11010001100100101110100000011001",
            "11010110100110010000011000100100",
            "11110100000011100011010110000101",
            "00010000011010101010000001110000",
            "00011001101001001100000100010110",
            "00011110001101110110110000001000",
            "00100111010010000111011101001100",
            "00110100101100001011110010110101",
            "00111001000111000000110010110011",
            "01001110110110001010101001001010",
            "01011011100111001100101001001111",
            "01101000001011100110111111110011",
            "01110100100011111000001011101110",
            "01111000101001010110001101101111",
            "10000100110010000111100000010100",
            "10001100110001110000001000001000",
            "10010000101111101111111111111010",
            "10100100010100000110110011101011",
            "10111110111110011010001111110111",
            "11000110011100010111100011110010" };

        private string[] k_64 = new string[80] {
"0100001010001010001011111001100011010111001010001010111000100010",
"0111000100110111010001001001000100100011111011110110010111001101",
"1011010111000000111110111100111111101100010011010011101100101111",
"1110100110110101110110111010010110000001100010011101101110111100",
"0011100101010110110000100101101111110011010010001011010100111000",
"0101100111110001000100011111000110110110000001011101000000011001",
"1001001000111111100000101010010010101111000110010100111110011011",
"1010101100011100010111101101010111011010011011011000000100011000",
"1101100000000111101010101001100010100011000000110000001001000010",
"0001001010000011010110110000000101000101011100000110111110111110",
"0010010000110001100001011011111001001110111001001011001010001100",
"0101010100001100011111011100001111010101111111111011010011100010",
"0111001010111110010111010111010011110010011110111000100101101111",
"1000000011011110101100011111111000111011000101101001011010110001",
"1001101111011100000001101010011100100101110001110001001000110101",
"1100000110011011111100010111010011001111011010010010011010010100",
"1110010010011011011010011100000110011110111100010100101011010010",
"1110111110111110010001111000011000111000010011110010010111100011",
"0000111111000001100111011100011010001011100011001101010110110101",
"0010010000001100101000011100110001110111101011001001110001100101",
"0010110111101001001011000110111101011001001010110000001001110101",
"0100101001110100100001001010101001101110101001101110010010000011",
"0101110010110000101010011101110010111101010000011111101111010100",
"0111011011111001100010001101101010000011000100010101001110110101",
"1001100000111110010100010101001011101110011001101101111110101011",
"1010100000110001110001100110110100101101101101000011001000010000",
"1011000000000011001001111100100010011000111110110010000100111111",
"1011111101011001011111111100011110111110111011110000111011100100",
"1100011011100000000010111111001100111101101010001000111111000010",
"1101010110100111100100010100011110010011000010101010011100100101",
"0000011011001010011000110101000111100000000000111000001001101111",
"0001010000101001001010010110011100001010000011100110111001110000",
"0010011110110111000010101000010101000110110100100010111111111100",
"0010111000011011001000010011100001011100001001101100100100100110",
"0100110100101100011011011111110001011010110001000010101011101101",
"0101001100111000000011010001001110011101100101011011001111011111",
"0110010100001010011100110101010010001011101011110110001111011110",
"0111011001101010000010101011101100111100011101111011001010101000",
"1000000111000010110010010010111001000111111011011010111011100110",
"1001001001110010001011001000010100010100100000100011010100111011",
"1010001010111111111010001010000101001100111100010000001101100100",
"1010100000011010011001100100101110111100010000100011000000000001",
"1100001001001011100010110111000011010000111110001001011110010001",
"1100011101101100010100011010001100000110010101001011111000110000",
"1101000110010010111010000001100111010110111011110101001000011000",
"1101011010011001000001100010010001010101011001011010100100010000",
"1111010000001110001101011000010101010111011100010010000000101010",
"0001000001101010101000000111000000110010101110111101000110111000",
"0001100110100100110000010001011010111000110100101101000011001000",
"0001111000110111011011000000100001010001010000011010101101010011",
"0010011101001000011101110100110011011111100011101110101110011001",
"0011010010110000101111001011010111100001100110110100100010101000",
"0011100100011100000011001011001111000101110010010101101001100011",
"0100111011011000101010100100101011100011010000011000101011001011",
"0101101110011100110010100100111101110111011000111110001101110011",
"0110100000101110011011111111001111010110101100101011100010100011",
"0111010010001111100000101110111001011101111011111011001011111100",
"0111100010100101011000110110111101000011000101110010111101100000",
"1000010011001000011110000001010010100001111100001010101101110010",
"1000110011000111000000100000100000011010011001000011100111101100",
"1001000010111110111111111111101000100011011000110001111000101000",
"1010010001010000011011001110101111011110100000101011110111101001",
"1011111011111001101000111111011110110010110001100111100100010101",
"1100011001110001011110001111001011100011011100100101001100101011",
"1100101000100111001111101100111011101010001001100110000110011100",
"1101000110000110101110001100011100100001110000001100001000000111",
"1110101011011010011111011101011011001101111000001110101100011110",
"1111010101111101010011110111111111101110011011101101000101111000",
"0000011011110000011001111010101001110010000101110110111110111010",
"0000101001100011011111011100010110100010110010001001100010100110",
"0001000100111111100110000000010010111110111110010000110110101110",
"0001101101110001000010110011010100010011000111000100011100011011",
"0010100011011011011101111111010100100011000001000111110110000100",
"0011001011001010101010110111101101000000110001110010010010010011",
"0011110010011110101111100000101000010101110010011011111010111100",
"0100001100011101011001111100010010011100000100000000110101001100",
"0100110011000101110101001011111011001011001111100100001010110110",
"0101100101111111001010011001110011111100011001010111111000101010",
"0101111111001011011011111010101100111010110101101111101011101100",
"0110110001000100000110011000110001001010010001110101100000010111" };

        private string mssgsz_FilledUpTo8Byte(string size_bin)
        {
            string size_filled = size_bin;
            double a = 64 - (size_bin.Length);
            for (int i = 0; i < a; i++)
                size_filled = "0" + size_filled;
            return size_filled;
        }
        //додати у функція перемінну н, яка дорівнює 512 для 224 та 256, 
        //та 1024 для 384, 512, 512/224, 512/256. Та змінити функцію
        private string mssgNbin(string ms, int c)
        {
            string message_N = ms;
            int b = (512 * c) - ms.Length - 64;
            for (int i = 0; i < b; i++)
                message_N += "0";
            return message_N;
        }
        //додати у функція перемінну н, яка дорівнює 32 для 224 та 256, 
        //та 64 для 384, 512, 512/224, 512/256. Та змінити функцію
        private void cut_into_N_bit_data_segments(string[,] arr, string str, int c)
        {
            for (int i = 0; i < c; i++)
            {
                for (int y = 0; y < 64; y++)
                {
                    if ((y >= 0) && (y <= 15))
                    {
                        for (int z = 0; z < 32; z++)
                        {
                            arr[i, y] += str[z + 32 * y + 512 * i];
                        }
                    }
                    else
                    {
                        for (int z = 0; z < 32; z++)
                        {
                            arr[i, y] += "0";
                        }
                    }
                }
            }
        }

        private string rotate(string s, string ro, int c)
        {
            string res = "";
            if (ro == "right")
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (i < (s.Length - c))
                    {
                        res += s[i];
                    }
                    else
                    {
                        res = res.Insert((i + c) % (s.Length), s[i].ToString());
                    }
                }
            }
            else
            if (ro == "left")
            {
                for (int i = (s.Length - 1); i >= 0; i--)
                {
                    if (i >= c)
                    {
                        res = s[i] + res;
                    }
                    else
                    {
                        res = res.Insert(s.Length - c, s[i].ToString());
                    }
                }
            }
            return res;
        }

        private string shift(string s, string ro, int c)
        {
            string res = "";
            if (ro == "right")
            {
                for (int i = 0; i < s.Length - c; i++)
                {
                    if (i < c)
                    {
                        res = res.Insert(i, "0");
                    }
                    res += s[i];
                }
            }
            else
            if (ro == "left")
            {
                res = "left";
            }
            return res;
        }

        private string XOR(string a, string b, string c)
        {
            string result = "";
            int length_a = a.Length;
            int length_b = b.Length;
            int length_c = c.Length;
            if ((length_a == length_b) && (length_b == length_c))
            {
                for (int i = 0; i < a.Length; i++)
                {
                    char x = a[i], y = b[i], z = c[i];
                    if (((x == '1') && (y != '1') && (z != '1')) || ((x != '1') && (y == '1') && (z != '1')) || ((x != '1') && (y != '1') && (z == '1')) || ((x == '1') && (y == '1') && (z == '1')))
                    {
                        result += "1";
                    }
                    else
                    {
                        result += "0";
                    }
                }
            }
            return result;
        }

        private string XOR(string a, string b)
        {
            string result = "";
            int length_a = a.Length;
            int length_b = b.Length;
            if (length_a == length_b)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (((a[i] == '1') && (b[i] != '1')) || ((a[i] != '1') && (b[i] == '1')))
                    {
                        result += "1";
                    }
                    else
                    {
                        result += "0";
                    }
                }
            }
            return result;
        }

        private string AND(string a, string b)
        {
            string result = "";
            for (int i = 0; i < a.Length; i++)
            {
                if ((a[i] == '1') && (b[i] == '1'))
                {
                    result += "1";
                }
                else
                {
                    result += "0";
                }
            }
            return result;
        }

        private string NOT(string a)
        {
            string result = "";
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == '1')
                {
                    result += "0";
                }
                else
                {
                    result += "1";
                }
            }
            return result;
        }

        private string CH(string x, string y, string z)
        {
            string result = "";
            result = XOR(AND(x, y), AND(NOT(x), z));
            return result;
        }

        private string MAJ(string x, string y, string z)
        {
            string result = "";
            result = XOR(AND(x, y), AND(x, z), AND(y, z));
            return result;
        }

        private string Digest(string a, string b, string c, string d, string e, string f, string g, string h, string t, string[] hconst)
        {
            string result = "";
            if (t == "bin")
            {
                result += summary_binarynumber(hconst[0], a);
                result += summary_binarynumber(hconst[1], b);
                result += summary_binarynumber(hconst[2], c);
                result += summary_binarynumber(hconst[3], d);
                result += summary_binarynumber(hconst[4], e);
                result += summary_binarynumber(hconst[5], f);
                result += summary_binarynumber(hconst[6], g);
                result += summary_binarynumber(hconst[7], h);
            }
            else
            if (t == "hex")
            {
                result += add_zero(DecToHex((BinToDec(hconst[0]) + BinToDec(a)) % 4294967296), 8);
                result += add_zero(DecToHex((BinToDec(hconst[1]) + BinToDec(b)) % 4294967296), 8);
                result += add_zero(DecToHex((BinToDec(hconst[2]) + BinToDec(c)) % 4294967296), 8);
                result += add_zero(DecToHex((BinToDec(hconst[3]) + BinToDec(d)) % 4294967296), 8);
                result += add_zero(DecToHex((BinToDec(hconst[4]) + BinToDec(e)) % 4294967296), 8);
                result += add_zero(DecToHex((BinToDec(hconst[5]) + BinToDec(f)) % 4294967296), 8);
                result += add_zero(DecToHex((BinToDec(hconst[6]) + BinToDec(g)) % 4294967296), 8);
                result += add_zero(DecToHex((BinToDec(hconst[7]) + BinToDec(h)) % 4294967296), 8);
            }
            return result;
        }

        private string SHA_2_224_256(string m, string t, string[] hconst, int output)
        {
            string DigestMessage = "";
            Encoding win1251 = Encoding.GetEncoding("Windows-1251");
            string text = m;
            string message = "";
            byte[] bytes = win1251.GetBytes(text);
            for (int i = 0; i < bytes.Length; i++)
            {
                string dw = add_zero(DecToBin(bytes[i]), 8);
                //richTextBox1.Text += $"{text[i]} = {bytes[i]}" + " = " + dw + "\n";
                message += dw;
            }
            int message_length = message.Length;
            richTextBox1.Text += "message_length = " + message_length + "\n";
            string message_length_bin = "";
            message_length_bin = DecToBin((UInt64)message_length);
            richTextBox1.Text += "In binary representation = " + message_length_bin + "\n";
            string message_length_bin_filled = "";
            message_length_bin_filled = mssgsz_FilledUpTo8Byte(message_length_bin);
            richTextBox1.Text += "Filled up to 8 Byte (64 Bits) = " + message_length_bin_filled + "\n";
            richTextBox1.Text += "Step 1 \nmessage = " + message + "\n";
            message += "1";
            richTextBox1.Text += "Step 2 \nmessage_2 = " + message + "\n";
            int count = count_chunk(message_length, 448);
            richTextBox1.Text += "count_chunk = " + count + "\n";
            message = mssgNbin(message, count);
            richTextBox1.Text += "Step 3 \nmessage_3 = " + message + "\n";
            message += message_length_bin_filled;
            richTextBox1.Text += "Step 4 \nmessage_4 = " + message + "\n";
            richTextBox1.Text = message.Length.ToString() + " " + count.ToString() + "\n";
            //richTextBox1.Text = m + "\n";
            //----------------------------------------------------------------------------------------------------//
            /*string h0 = hconst[0], h1 = hconst[1], h2 = hconst[2], h3 = hconst[3];
            string h4 = hconst[4], h5 = hconst[5], h6 = hconst[6], h7 = hconst[7];*/
            for (int z = 0; z < count; z++)
            {
                string[,] w = new string[count, 64];
                cut_into_N_bit_data_segments(w, message, count);
                //richTextBox1.Text += "Loop 1 \n";
                /*for (int i = 0; i < 64; i++)
                {
                    richTextBox1.Text += "w[ 0 ," + i + "] = " + w[0, i] + "\t";
                    richTextBox1.Text += "w[ 1 ," + i + "] = " + w[1, i] + "\n";
                }*/
                string s0 = "", s1 = "";
                for (int i = 16; i < 64; i++)
                {
                    string rot = "right";
                    s0 = XOR(rotate(w[z, i - 15], rot, 7), rotate(w[z, i - 15], rot, 18), shift(w[z, i - 15], rot, 3));
                    s1 = XOR(rotate(w[z, i - 2], rot, 17), rotate(w[z, i - 2], rot, 19), shift(w[z, i - 2], rot, 10));
                    w[z, i] = summary_binarynumber(w[z, i - 16], s0);
                    if (w[z, i].Length == 33)
                        w[z, i] = w[z, i].Remove(0, 1);
                    w[z, i] = summary_binarynumber(w[z, i], w[z, i - 7]);
                    if (w[z, i].Length == 33)
                        w[z, i] = w[z, i].Remove(0, 1);
                    w[z, i] = summary_binarynumber(w[z, i], s1);
                    if (w[z, i].Length == 33)
                        w[z, i] = w[z, i].Remove(0, 1);
                    //w[z, i] = XOR(w[z, i], "100000000000000000000000000000000");
                    // замінити на мод  xor 1 + 0 *31
                    //w[z, i] = add_zero(DecToBin((BinToDec(w[z, i - 16]) + BinToDec(s0) + BinToDec(w[z, i - 7]) + BinToDec(s1)) % 4294967296).ToString(), 32);
                    //richTextBox2.Text += "\n" + " == " + ((32+32)%("".Length+32)).ToString();
                    //richTextBox2.Text += summary_binarynumber(w[z, i - 16], s0);
                }
                /*for (int i = 0; i < 64; i++)
                {
                    richTextBox2.Text += "w[" + i + "] = " + w[z, i] + "\n";
                }*/
                //richTextBox1.Text += "\n\nLoop 2 \n";
                string a, b, c, d, e, f, g, h;
                string S1 = "", S0 = "";
                string ch = "", maj = "";
                string temp1 = "", temp2 = "";
                a = hconst[0];
                b = hconst[1];
                c = hconst[2];
                d = hconst[3];
                e = hconst[4];
                f = hconst[5];
                g = hconst[6];
                h = hconst[7];
                /*richTextBox2.Text += "z = " + z + '\n';
                richTextBox2.Text += DecToHex_SHA3(BinToDec(a)) + '\n';
                richTextBox2.Text += DecToHex_SHA3(BinToDec(b)) + '\n';
                richTextBox2.Text += DecToHex_SHA3(BinToDec(c)) + '\n';
                richTextBox2.Text += DecToHex_SHA3(BinToDec(d)) + '\n';
                richTextBox2.Text += DecToHex_SHA3(BinToDec(e)) + '\n';
                richTextBox2.Text += DecToHex_SHA3(BinToDec(f)) + '\n';
                richTextBox2.Text += DecToHex_SHA3(BinToDec(g)) + '\n';
                richTextBox2.Text += DecToHex_SHA3(BinToDec(h)) + '\n';*/
                for (int i = 0; i < 64; i++)
                {
                    /*string rot = "right";
                    S1 = XOR(rotate(e, rot, 6), rotate(e, rot, 11), rotate(e, rot, 25));
                    ch = CH(e, f, g);
                    temp1 = add_zero(DecToBin((BinToDec(h) + BinToDec(S1) + BinToDec(ch) + BinToDec(k[i]) + BinToDec(w[z, i])) % 4294967296).ToString(), 32);
                    S0 = XOR(rotate(a, rot, 2), rotate(a, rot, 13), rotate(a, rot, 22));
                    maj = MAJ(a, b, c);
                    temp2 = add_zero(DecToBin((BinToDec(S0) + BinToDec(maj)) % 4294967296).ToString(), 32);
                    h = g;
                    g = f;
                    f = e;
                    e = add_zero(DecToBin((BinToDec(d) + BinToDec(temp1)) % 4294967296).ToString(), 32);
                    d = c;
                    c = b;
                    b = a;
                    a = add_zero(DecToBin((BinToDec(temp1) + BinToDec(temp2)) % 4294967296).ToString(), 32);*/
                    string rot = "right";
                    S1 = XOR(rotate(e, rot, 6), rotate(e, rot, 11), rotate(e, rot, 25));
                    ch = CH(e, f, g);
                    temp1 = summary_binarynumber(h, S1);
                    if (temp1.Length == 33)
                        temp1 = temp1.Remove(0, 1);
                    temp1 = summary_binarynumber(h, S1);
                    if (temp1.Length == 33)
                        temp1 = temp1.Remove(0, 1);
                    temp1 = summary_binarynumber(temp1, ch);
                    if (temp1.Length == 33)
                        temp1 = temp1.Remove(0, 1);
                    temp1 = summary_binarynumber(temp1, k_64[i]);
                    if (temp1.Length == 33)
                        temp1 = temp1.Remove(0, 1);
                    temp1 = summary_binarynumber(temp1, w[z, i]);
                    if (temp1.Length == 33)
                        temp1 = temp1.Remove(0, 1);
                    S0 = XOR(rotate(a, rot, 2), rotate(a, rot, 13), rotate(a, rot, 22));
                    maj = MAJ(a, b, c);
                    temp2 = summary_binarynumber(S0, maj);
                    if (temp2.Length == 33)
                        temp2 = temp2.Remove(0, 1);
                    h = g;
                    g = f;
                    f = e;
                    e = summary_binarynumber(d, temp1);
                    if (e.Length == 33)
                        e = e.Remove(0, 1);
                    d = c;
                    c = b;
                    b = a;
                    a = summary_binarynumber(temp1, temp2);
                    if (a.Length == 33)
                        a = a.Remove(0, 1);
                }
                DigestMessage = Digest(a, b, c, d, e, f, g, h, t, hconst);
                string temp = "";
                for (int i = 0; i < output / 8 * 2; i += 2)
                {
                    temp += DigestMessage.Substring(i, 2);
                }
                DigestMessage = temp;
                if (count != 1)
                {
                    hconst[0] = add_zero(DecToBin((BinToDec(hconst[0]) + BinToDec(a)) % 4294967296).ToString(), 32);
                    hconst[1] = add_zero(DecToBin((BinToDec(hconst[1]) + BinToDec(b)) % 4294967296).ToString(), 32);
                    hconst[2] = add_zero(DecToBin((BinToDec(hconst[2]) + BinToDec(c)) % 4294967296).ToString(), 32);
                    hconst[3] = add_zero(DecToBin((BinToDec(hconst[3]) + BinToDec(d)) % 4294967296).ToString(), 32);
                    hconst[4] = add_zero(DecToBin((BinToDec(hconst[4]) + BinToDec(e)) % 4294967296).ToString(), 32);
                    hconst[5] = add_zero(DecToBin((BinToDec(hconst[5]) + BinToDec(f)) % 4294967296).ToString(), 32);
                    hconst[6] = add_zero(DecToBin((BinToDec(hconst[6]) + BinToDec(g)) % 4294967296).ToString(), 32);
                    hconst[7] = add_zero(DecToBin((BinToDec(hconst[7]) + BinToDec(h)) % 4294967296).ToString(), 32);
                }
                /*else
                {
                    hconst[0] = "01101010000010011110011001100111";
                    hconst[1] = "10111011011001111010111010000101";
                    hconst[2] = "00111100011011101111001101110010";
                    hconst[3] = "10100101010011111111010100111010";
                    hconst[4] = "01010001000011100101001001111111";
                    hconst[5] = "10011011000001010110100010001100";
                    hconst[6] = "00011111100000111101100110101011";
                    hconst[7] = "01011011111000001100110100011001";
                }*/
            }
            return DigestMessage;
        }

        private string SHA_2_384(string m, string t)
        {
            string DigestMessage = "";
            Encoding win1251 = Encoding.GetEncoding("Windows-1251");
            string text = m;
            string message = "";
            byte[] bytes = win1251.GetBytes(text);
            using (SHA384 sha384Hash = SHA384.Create())
            {
                //From String to byte array
                byte[] sourceBytes = Encoding.UTF8.GetBytes(text);
                byte[] hashBytes = sha384Hash.ComputeHash(sourceBytes);
                DigestMessage = BitConverter.ToString(hashBytes).Replace("-", String.Empty);

                //Console.WriteLine("The SHA384 hash of " + text + " is: " + hash);
            }
            /*for (int i = 0; i < bytes.Length; i++)
            {
                DigestMessage += "Тут";
            }
            /*for (int i = 0; i < bytes.Length; i++)
            {
                string dw = add_zero(DecToBin(bytes[i]), 8);
                richTextBox1.Text += $"{text[i]} = {bytes[i]}" + " = " + dw + "\n";
                message += dw;
            }
            int message_length = message.Length;
            richTextBox1.Text += "message_length = " + message_length + "\n";
            string message_length_bin = "";
            message_length_bin = DecToBin((UInt64)message_length);
            richTextBox1.Text += "In binary representation = " + message_length_bin + "\n";
            string message_length_bin_filled = "";
            message_length_bin_filled = mssgsz_FilledUpTo8Byte(message_length_bin);
            richTextBox1.Text += "Filled up to 8 Byte (64 Bits) = " + message_length_bin_filled + "\n";
            richTextBox1.Text += "Step 1 \nmessage = " + message + "\n";
            message += "1";
            richTextBox1.Text += "Step 2 \nmessage_2 = " + message + "\n";
            int count = count_chunk(message_length, 960);
            richTextBox1.Text += "count_chunk = " + count + "\n";
            message = mssg960bin(message, count);
            richTextBox1.Text += "Step 3 \nmessage_3 = " + message + "\n";
            message += message_length_bin_filled;
            richTextBox1.Text += "Step 4 \nmessage_4 = " + message + "\n";
            for (int z = 0; z < count; z++)
            {
                string[,] w = new string[count, 80];
                cut_into_64_bit_data_segments(w, message, count);
                richTextBox1.Text += "Loop 1 \n";
                /*for (int i = 0; i < 64; i++)
                {
                    richTextBox1.Text += "w[ 0 ," + i + "] = " + w[0, i] + "\t";
                    richTextBox1.Text += "w[ 1 ," + i + "] = " + w[1, i] + "\n";
                }
                string s0 = "", s1 = "";
                for (int i = 16; i < 80; i++)
                {
                    string rot = "right";
                    s0 = XOR(rotate(w[z, i - 15], rot, 7), rotate(w[z, i - 15], rot, 18), shift(w[z, i - 15], rot, 3));
                    s1 = XOR(rotate(w[z, i - 2], rot, 17), rotate(w[z, i - 2], rot, 19), shift(w[z, i - 2], rot, 10));
                    w[z, i] = summary_binarynumber(w[z, i - 16], s0);
                    if (w[z, i].Length == 65)
                        w[z, i] = w[z, i].Remove(0, 1);
                    w[z, i] = summary_binarynumber(w[z, i], w[z, i - 7]);
                    if (w[z, i].Length == 65)
                        w[z, i] = w[z, i].Remove(0, 1);
                    w[z, i] = summary_binarynumber(w[z, i], s1);
                    if (w[z, i].Length == 65)
                        w[z, i] = w[z, i].Remove(0, 1);
                    //w[z, i] = XOR(w[z, i], "100000000000000000000000000000000");
                    // замінити на мод  xor 1 + 0 *31
                    //w[z, i] = add_zero(DecToBin((BinToDec(w[z, i - 16]) + BinToDec(s0) + BinToDec(w[z, i - 7]) + BinToDec(s1)) % 4294967296).ToString(), 32);
                    //richTextBox2.Text += "\n" + " == " + ((32+32)%("".Length+32)).ToString();
                    //richTextBox2.Text += summary_binarynumber(w[z, i - 16], s0);
                }
                /*for (int i = 0; i < 64; i++)
                {
                    richTextBox2.Text += "w[" + i + "] = " + w[z, i] + "\n";
                }
                richTextBox1.Text += "\n\nLoop 2 \n";
                string a, b, c, d, e, f, g, h;
                string S1 = "", S0 = "";
                string ch = "", maj = "";
                string temp1 = "", temp2 = "";
                a = hconst[0];
                b = hconst[1];
                c = hconst[2];
                d = hconst[3];
                e = hconst[4];
                f = hconst[5];
                g = hconst[6];
                h = hconst[7];
                /*richTextBox2.Text += "z = " + z + '\n';
                richTextBox2.Text += DecToHex_SHA3(BinToDec(a)) + '\n';
                richTextBox2.Text += DecToHex_SHA3(BinToDec(b)) + '\n';
                richTextBox2.Text += DecToHex_SHA3(BinToDec(c)) + '\n';
                richTextBox2.Text += DecToHex_SHA3(BinToDec(d)) + '\n';
                richTextBox2.Text += DecToHex_SHA3(BinToDec(e)) + '\n';
                richTextBox2.Text += DecToHex_SHA3(BinToDec(f)) + '\n';
                richTextBox2.Text += DecToHex_SHA3(BinToDec(g)) + '\n';
                richTextBox2.Text += DecToHex_SHA3(BinToDec(h)) + '\n';
                for (int i = 0; i < 1; i++)
                {
                    string rot = "right";
                    S1 = XOR(rotate(e, rot, 6), rotate(e, rot, 11), rotate(e, rot, 25));
                    ch = CH(e, f, g);
                    temp1 = summary_binarynumber(h, S1);
                    if (temp1.Length == 65)
                        temp1 = temp1.Remove(0, 1);
                    temp1 = summary_binarynumber(temp1, ch);
                    if (temp1.Length == 65)
                        temp1 = temp1.Remove(0, 1);
                    temp1 = summary_binarynumber(temp1, k_64[i]);
                    if (temp1.Length == 65)
                        temp1 = temp1.Remove(0, 1);
                    temp1 = summary_binarynumber(temp1, w[z, i]);
                    if (temp1.Length == 65)
                        temp1 = temp1.Remove(0, 1);
                    S0 = XOR(rotate(a, rot, 2), rotate(a, rot, 13), rotate(a, rot, 22));
                    maj = MAJ(a, b, c);
                    temp2 = summary_binarynumber(S0, maj);
                    if (temp2.Length == 65)
                        temp2 = temp2.Remove(0, 1);
                    h = g;
                    g = f;
                    f = e;
                    e = summary_binarynumber(temp1, d);
                    if (e.Length == 65)
                        e = e.Remove(0, 1);
                    d = c;
                    c = b;
                    b = a;
                    a = summary_binarynumber(temp1, temp2);
                    if (a.Length == 65)
                        a = a.Remove(0, 1);
                    richTextBox1.Text += "a " + a + "\n";
                    richTextBox1.Text += "e " + e + "\n";
                    richTextBox1.Text += "k " + k_64[i] + "\n";
                    richTextBox1.Text += "ch " + ch + "\n";
                    richTextBox1.Text += "s1 " + S1 + "\n";
                    richTextBox1.Text += "temp1 " + temp1 + "\n";
                }
                DigestMessage = Digest(a, b, c, d, e, f, g, h, t, hconst);
                string temp = "";
                for (int i = 0; i < output / 8 * 2; i += 2)
                {
                    temp += DigestMessage.Substring(i, 2);
                }
                DigestMessage = temp;
                if (count != 1)
                {
                    hconst[0] = add_zero(DecToBin((BinToDec(hconst[0]) + BinToDec(a)) % 4294967296).ToString(), 32);
                    hconst[1] = add_zero(DecToBin((BinToDec(hconst[1]) + BinToDec(b)) % 4294967296).ToString(), 32);
                    hconst[2] = add_zero(DecToBin((BinToDec(hconst[2]) + BinToDec(c)) % 4294967296).ToString(), 32);
                    hconst[3] = add_zero(DecToBin((BinToDec(hconst[3]) + BinToDec(d)) % 4294967296).ToString(), 32);
                    hconst[4] = add_zero(DecToBin((BinToDec(hconst[4]) + BinToDec(e)) % 4294967296).ToString(), 32);
                    hconst[5] = add_zero(DecToBin((BinToDec(hconst[5]) + BinToDec(f)) % 4294967296).ToString(), 32);
                    hconst[6] = add_zero(DecToBin((BinToDec(hconst[6]) + BinToDec(g)) % 4294967296).ToString(), 32);
                    hconst[7] = add_zero(DecToBin((BinToDec(hconst[7]) + BinToDec(h)) % 4294967296).ToString(), 32);
                }
                /*else
                {
                    hconst[0] = "01101010000010011110011001100111";
                    hconst[1] = "10111011011001111010111010000101";
                    hconst[2] = "00111100011011101111001101110010";
                    hconst[3] = "10100101010011111111010100111010";
                    hconst[4] = "01010001000011100101001001111111";
                    hconst[5] = "10011011000001010110100010001100";
                    hconst[6] = "00011111100000111101100110101011";
                    hconst[7] = "01011011111000001100110100011001";
                }
            }*/
            return DigestMessage;
        }

        private string SHA_2_512(string m, string t)
        {
            string DigestMessage = "";
            Encoding win1251 = Encoding.GetEncoding("Windows-1251");
            string text = m;
            string message = "";
            byte[] bytes = win1251.GetBytes(text);
            using (SHA512 sha512Hash = SHA512.Create())
            {
                //From String to byte array
                byte[] sourceBytes = Encoding.UTF8.GetBytes(text);
                byte[] hashBytes = sha512Hash.ComputeHash(sourceBytes);
                DigestMessage = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
                //Console.WriteLine("The SHA384 hash of " + text + " is: " + hash);
            }
            return DigestMessage;
        }

        private int positive(int a)
        {
            int b = a % 5;
            if (b < 0)
            {
                b = 5 + a;
            }
            return b;
        }

        private string DecToBin_SHA3(UInt64 b)
        {
            string a = "";
            if (b == 0)
            {
                a = "0";
            }
            while (b > 0)
            {
                a = (b % 2) + a;
                b /= 2;
            }
            return a;
        }

        private UInt64 HexToDec_SHA3(string a)
        {
            UInt64 result = 0;
            int length = a.Length;
            int ex = length - 1;
            for (int i = 0; i < length; i++)
            {
                {
                    int q = 0;
                    switch (a[i])
                    {
                        case '0':
                            q = 0;
                            break;
                        case '1':
                            q = 1;
                            break;
                        case '2':
                            q = 2;
                            break;
                        case '3':
                            q = 3;
                            break;
                        case '4':
                            q = 4;
                            break;
                        case '5':
                            q = 5;
                            break;
                        case '6':
                            q = 6;
                            break;
                        case '7':
                            q = 7;
                            break;
                        case '8':
                            q = 8;
                            break;
                        case '9':
                            q = 9;
                            break;
                        case 'a':
                        case 'A':
                            q = 10;
                            break;
                        case 'b':
                        case 'B':
                            q = 11;
                            break;
                        case 'c':
                        case 'C':
                            q = 12;
                            break;
                        case 'd':
                        case 'D':
                            q = 13;
                            break;
                        case 'e':
                        case 'E':
                            q = 14;
                            break;
                        case 'f':
                        case 'F':
                            q = 15;
                            break;
                    }
                    result += (UInt64)q * (UInt64)Math.Pow(16, ex);
                }
                ex--;
            }
            return result;
        }

        private string DecToHex_SHA3(UInt64 b)
        {
            string hex = "";
            if (b == 0)
            {
                hex = "0";
            }
            while (b > 0)
            {
                if ((b % 16) == 10)
                {
                    hex = "a" + hex;
                }
                else
                if ((b % 16) == 11)
                {
                    hex = "b" + hex;
                }
                else
                if ((b % 16) == 12)
                {
                    hex = "c" + hex;
                }
                else
                    if ((b % 16) == 13)
                {
                    hex = "d" + hex;
                }
                else
                if ((b % 16) == 14)
                {
                    hex = "e" + hex;
                }
                else
                if ((b % 16) == 15)
                {
                    hex = "f" + hex;
                }
                else
                {
                    hex = (b % 16) + hex;
                }
                b /= 16;
            }
            return hex;
        }

        private string SHA_3(string m, int r, int c)
        {
            string output = "";
            Encoding win1251 = Encoding.GetEncoding("Windows-1251");
            string text = m;
            byte[] bytes = win1251.GetBytes(text);
            //text += "The input in bytes \n";
            string[] by = new string[bytes.Length];
            for (int i = 0; i < bytes.Length; i++)
            {
                by[i] = add_zero(DecToBin(bytes[i]), 8);
                //text += $"{text[i]} = ASCII {bytes[i]}" + " = " + by[i] + "\n";
                //richTextBox2.Text += add_zero(DecToHex_SHA3(BinToDec(by[i])), 2) + " ";
            }
            //Перевірити правильність перетворення згідно https://keccak.team/keccak_bits_and_bytes.html
            //text += "The input in bits \n";
            string bi = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                string temp = "";
                temp = by[i];
                for (int y = 7; y > -1; y--)
                {
                    bi += temp[y];
                }
            }
            int count = count_chunk(bi.Length, r);
            //richTextBox2.Text += "count " + count.ToString() + "\n";
            string[] bits_array = new string[count];
            for (int i = 0; i < count; i++)
            {
                if (count == 1)
                {
                    for (int j = 0; j < bi.Length; j++)
                    {
                        bits_array[i] += bi[j];
                    }
                    bits_array[i] += "01";
                    int pad = r - (bits_array[i].Length % r) - 2;
                    bits_array[i] += "1";
                    for (int j = 0; j < pad; j++)
                    {
                        bits_array[i] += "0";
                    }
                    bits_array[i] += "1";
                    for (int j = 0; j < c; j++)
                    {
                        bits_array[i] += "0";
                    }
                }
                else
                {
                    if ((count > 1) && (i != (count - 1)))
                    {
                        for (int j = 0; j < r; j++)
                        {
                            bits_array[i] += bi[j + r * i];
                        }
                        for (int j = 0; j < c; j++)
                        {
                            bits_array[i] += "0";
                        }
                    }
                    else
                    {
                        for (int j = 0; j < (bi.Length % r); j++)
                        {
                            bits_array[i] += bi[j + r * i];
                        }
                        bits_array[i] += "01";
                        int pad = r - (bits_array[i].Length % r) - 2;
                        bits_array[i] += "1";
                        for (int j = 0; j < pad; j++)
                        {
                            bits_array[i] += "0";
                        }
                        bits_array[i] += "1";
                        for (int j = 0; j < c; j++)
                        {
                            bits_array[i] += "0";
                        }
                    }
                }
            }
            /*
            bi += "01";
            //text += bi + "\n";
            int pad = r - (bi.Length % 1088) - 2;
            bi += "1";
            for (int i = 0; i < pad; i++)
            {
                bi += "0";
            }
            bi += "1";
            for (int i = 0; i < c; i++)
            {
                bi += "0";
            }
            */
            string[] state = new string[200];
            for (int i = 0; i < state.Length; i++)
            {
                state[i] = "00";
                /*//Табличка
                int te = (i + 1) % 16;
                if (te == 0)
                {
                    richTextBox2.Text += state[i] + " ";
                    richTextBox2.Text += "\n";
                }
                else
                {
                    richTextBox2.Text += state[i] + " ";
                }*/
            }
            for (int n = 0; n < count; n++)
            {
                //richTextBox1.Text += "length " + bi.Length;
                //richTextBox2.Text += "Chunk" + n + "\n";
                //richTextBox2.Text += "About to Absorb data" + "\n";
                //richTextBox2.Text += "State (in bytes)" + "\n";
                //richTextBox2.Text += "\n";
                //richTextBox2.Text += "Data to be absorbed" + "\n";
                string[] absorbed_arr = new string[200];
                for (int i = 0; i < absorbed_arr.Length; i++)
                {
                    for (int j = 8 + 8 * i; j > 0 + 8 * i; j--)
                    {
                        absorbed_arr[i] += bits_array[n][j - 1];
                    }
                    absorbed_arr[i] = add_zero(DecToHex_SHA3(BinToDec(absorbed_arr[i])), 2);
                    //richTextBox2.Text += absorbed_arr[i] + " ";
                }
                //richTextBox2.Text += "\n";

                {
                    /*absorbed_arr_16[0] = "d3";
                    absorbed_arr_16[1] = "00";
                    absorbed_arr_16[2] = "00";
                    /*absorbed_arr[0] = "79";
                    absorbed_arr[1] = "4D";
                    absorbed_arr[2] = "92";
                    absorbed_arr[3] = "19";
                    absorbed_arr[4] = "DE";
                    absorbed_arr[5] = "90";
                    absorbed_arr[6] = "39";
                    absorbed_arr[7] = "84";
                    absorbed_arr[8] = "3C";
                    absorbed_arr[9] = "2F";
                    absorbed_arr[10] = "1A";
                    absorbed_arr[11] = "9D";
                    absorbed_arr[12] = "16";
                    absorbed_arr[13] = "5B";
                    absorbed_arr[14] = "52";
                    absorbed_arr[15] = "61";
                    absorbed_arr[16] = "C5";
                    absorbed_arr[17] = "3C";
                    absorbed_arr[18] = "F3";
                    absorbed_arr[19] = "0C";
                    absorbed_arr[20] = "77";
                    absorbed_arr[21] = "4F";
                    absorbed_arr[22] = "ED";
                    absorbed_arr[23] = "1E";
                    absorbed_arr[24] = "30";
                    absorbed_arr[25] = "7E";
                    absorbed_arr[26] = "EE";
                    absorbed_arr[27] = "9C";
                    absorbed_arr[28] = "9B";
                    absorbed_arr[29] = "9B";
                    absorbed_arr[30] = "7B";
                    absorbed_arr[31] = "F6";
                    absorbed_arr[32] = "04";
                    absorbed_arr[33] = "D6";
                    absorbed_arr[34] = "9B";
                    absorbed_arr[35] = "67";
                    absorbed_arr[36] = "86";
                    absorbed_arr[37] = "5D";
                    absorbed_arr[38] = "3A";
                    absorbed_arr[39] = "7F";
                    absorbed_arr[40] = "36";
                    absorbed_arr[41] = "57";
                    absorbed_arr[42] = "87";
                    absorbed_arr[43] = "56";
                    absorbed_arr[44] = "F5";
                    absorbed_arr[45] = "0A";
                    absorbed_arr[46] = "BA";
                    absorbed_arr[47] = "D8";
                    absorbed_arr[48] = "68";
                    absorbed_arr[49] = "9A";
                    absorbed_arr[50] = "6E";
                    absorbed_arr[51] = "31";
                    absorbed_arr[52] = "66";
                    absorbed_arr[53] = "4D";
                    absorbed_arr[54] = "69";
                    absorbed_arr[55] = "D0";
                    absorbed_arr[56] = "72";
                    absorbed_arr[57] = "99";
                    absorbed_arr[58] = "7C";
                    absorbed_arr[59] = "7E";
                    absorbed_arr[60] = "34";
                    absorbed_arr[61] = "85";
                    absorbed_arr[62] = "BD";
                    absorbed_arr[63] = "9F";
                    absorbed_arr[64] = "DD";
                    absorbed_arr[65] = "B5";
                    absorbed_arr[66] = "B4";
                    absorbed_arr[67] = "E9";
                    absorbed_arr[68] = "E4";
                    absorbed_arr[69] = "CF";
                    absorbed_arr[70] = "EA";
                    absorbed_arr[71] = "EC";
                    absorbed_arr[72] = "21";
                    absorbed_arr[73] = "16";
                    absorbed_arr[74] = "75";
                    absorbed_arr[75] = "27";
                    absorbed_arr[76] = "52";
                    absorbed_arr[77] = "47";
                    absorbed_arr[78] = "79";
                    absorbed_arr[79] = "A4";
                    absorbed_arr[80] = "E9";
                    absorbed_arr[81] = "DB";
                    absorbed_arr[82] = "CE";
                    absorbed_arr[83] = "32";
                    absorbed_arr[84] = "08";
                    absorbed_arr[85] = "A8";
                    absorbed_arr[86] = "E4";
                    absorbed_arr[87] = "62";
                    absorbed_arr[88] = "85";
                    absorbed_arr[89] = "D2";
                    absorbed_arr[90] = "2D";
                    absorbed_arr[91] = "6A";
                    absorbed_arr[92] = "54";
                    absorbed_arr[93] = "14";
                    absorbed_arr[94] = "03";
                    absorbed_arr[95] = "4F";
                    absorbed_arr[96] = "59";
                    absorbed_arr[97] = "39";
                    absorbed_arr[98] = "0F";
                    absorbed_arr[99] = "43";
                    absorbed_arr[100] = "EF";
                    absorbed_arr[101] = "03";
                    absorbed_arr[102] = "8F";
                    absorbed_arr[103] = "D5";
                    absorbed_arr[104] = "17";
                    absorbed_arr[105] = "D5";
                    absorbed_arr[106] = "64";
                    absorbed_arr[107] = "F3";
                    absorbed_arr[108] = "7F";
                    absorbed_arr[109] = "68";
                    absorbed_arr[110] = "73";
                    absorbed_arr[111] = "25";
                    absorbed_arr[112] = "42";
                    absorbed_arr[113] = "21";
                    absorbed_arr[114] = "A3";
                    absorbed_arr[115] = "A5";
                    absorbed_arr[116] = "FB";
                    absorbed_arr[117] = "38";
                    absorbed_arr[118] = "E6";
                    absorbed_arr[119] = "E5";
                    absorbed_arr[120] = "2E";
                    absorbed_arr[121] = "4F";
                    absorbed_arr[122] = "CF";
                    absorbed_arr[123] = "39";
                    absorbed_arr[124] = "C2";
                    absorbed_arr[125] = "0B";
                    absorbed_arr[126] = "F5";
                    absorbed_arr[127] = "80";
                    absorbed_arr[128] = "2F";
                    absorbed_arr[129] = "2D";
                    absorbed_arr[130] = "EE";
                    absorbed_arr[131] = "83";
                    absorbed_arr[132] = "D9";
                    absorbed_arr[133] = "89";
                    absorbed_arr[134] = "1E";
                    absorbed_arr[135] = "8F";
                    absorbed_arr[136] = "12";
                    absorbed_arr[137] = "C3";
                    absorbed_arr[138] = "DE";
                    absorbed_arr[139] = "A6";
                    absorbed_arr[140] = "B3";
                    absorbed_arr[141] = "EA";
                    absorbed_arr[142] = "E2";
                    absorbed_arr[143] = "BF";
                    absorbed_arr[144] = "1A";
                    absorbed_arr[145] = "11";
                    absorbed_arr[146] = "E6";
                    absorbed_arr[147] = "BD";
                    absorbed_arr[148] = "E5";
                    absorbed_arr[149] = "2C";
                    absorbed_arr[150] = "34";
                    absorbed_arr[151] = "0C";
                    absorbed_arr[152] = "C7";
                    absorbed_arr[153] = "D2";
                    absorbed_arr[154] = "81";
                    absorbed_arr[155] = "D2";
                    absorbed_arr[156] = "62";
                    absorbed_arr[157] = "BA";
                    absorbed_arr[158] = "38";
                    absorbed_arr[159] = "2A";
                    absorbed_arr[160] = "E5";
                    absorbed_arr[161] = "8E";
                    absorbed_arr[162] = "34";
                    absorbed_arr[163] = "B3";
                    absorbed_arr[164] = "6C";
                    absorbed_arr[165] = "38";
                    absorbed_arr[166] = "88";
                    absorbed_arr[167] = "0E";
                    absorbed_arr[168] = "44";
                    absorbed_arr[169] = "FE";
                    absorbed_arr[170] = "23";
                    absorbed_arr[171] = "15";
                    absorbed_arr[172] = "39";
                    absorbed_arr[173] = "4C";
                    absorbed_arr[174] = "CA";
                    absorbed_arr[175] = "75";
                    absorbed_arr[176] = "A2";
                    absorbed_arr[177] = "0D";
                    absorbed_arr[178] = "6C";
                    absorbed_arr[179] = "EE";
                    absorbed_arr[180] = "68";
                    absorbed_arr[181] = "73";
                    absorbed_arr[182] = "0F";
                    absorbed_arr[183] = "2F";
                    absorbed_arr[184] = "88";
                    absorbed_arr[185] = "9B";
                    absorbed_arr[186] = "0C";
                    absorbed_arr[187] = "AA";
                    absorbed_arr[188] = "F1";
                    absorbed_arr[189] = "26";
                    absorbed_arr[190] = "D3";
                    absorbed_arr[191] = "F0";
                    absorbed_arr[192] = "CE";
                    absorbed_arr[193] = "EC";
                    absorbed_arr[194] = "E9";
                    absorbed_arr[195] = "52";
                    absorbed_arr[196] = "73";
                    absorbed_arr[197] = "0B";
                    absorbed_arr[198] = "1E";
                    absorbed_arr[199] = "21";*/
                }

                /*for (int i = 0; i < absorbed_arr.Length; i++)
                {
                    richTextBox2.Text += absorbed_arr[i] + " ";
                }*/
                //richTextBox2.Text += "\n";
                //richTextBox2.Text += "Xor'd state (in bytes)" + "\n";
                string[] xor_d = new string[200];
                for (int i = 0; i < 200; i++)
                {
                    xor_d[i] = add_zero(DecToHex_SHA3(BinToDec(XOR(add_zero(DecToBin_SHA3(HexToDec_SHA3(state[i])), 8), add_zero(DecToBin_SHA3(HexToDec_SHA3(absorbed_arr[i])), 8)))), 2);
                }
                /*for (int i = 0; i < 200; i++)
                {
                    richTextBox2.Text += xor_d[i] + " ";
                }*/

                //richTextBox2.Text += "\n";
                //richTextBox2.Text += "Xor'd state (as lanes of integers)" + "\n";
                string[,] xor_d_lanes_2 = new string[5, 5];
                string[,] xor_d_lanes_16 = new string[5, 5];
                int la = 0;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        for (int l = 0; l < 8; l++)
                        {
                            xor_d_lanes_16[i, j] = xor_d[la] + xor_d_lanes_16[i, j];
                            xor_d_lanes_2[i, j] = add_zero(DecToBin_SHA3(HexToDec_SHA3(xor_d[la])), 8) + xor_d_lanes_2[i, j];
                            la++;
                        }
                        //richTextBox2.Text += "[ " + i + " , " + j + " ] = " + xor_d_lanes_16[i, j] + "\n";
                    }
                }
                for (int i = 0; i < 24; i++)
                {
                    //richTextBox2.Text += "Round #" + i + "\n";
                    //richTextBox2.Text += "After θ (Theta)" + "\n";
                    string[] C_2 = new string[5];
                    string[] C_16 = new string[5];
                    string[] D_2 = new string[5];
                    string[] D_16 = new string[5];

                    for (int x = 0; x < 5; x++)
                    {
                        string tt = "";
                        for (int y = 0; y < 8; y++)
                        {
                            string temp_0 = "", temp_1 = "", temp_2 = "", temp_3 = "", temp_4 = "";
                            temp_0 = xor_d_lanes_16[0, x].Substring(y * 2, 2);
                            temp_1 = xor_d_lanes_16[1, x].Substring(y * 2, 2);
                            temp_2 = xor_d_lanes_16[2, x].Substring(y * 2, 2);
                            temp_3 = xor_d_lanes_16[3, x].Substring(y * 2, 2);
                            temp_4 = xor_d_lanes_16[4, x].Substring(y * 2, 2);
                            tt += XOR(XOR(XOR(XOR(add_zero(DecToBin_SHA3(HexToDec_SHA3(temp_0)), 8), add_zero(DecToBin_SHA3(HexToDec_SHA3(temp_1)), 8)), add_zero(DecToBin_SHA3(HexToDec_SHA3(temp_2)), 8)), add_zero(DecToBin_SHA3(HexToDec_SHA3(temp_3)), 8)), add_zero(DecToBin_SHA3(HexToDec_SHA3(temp_4)), 8));
                        }
                        for (int y = 0; y < 8; y++)
                        {
                            C_2[x] += tt.Substring(y * 8, 8);
                            C_16[x] += add_zero(DecToHex_SHA3(BinToDec(tt.Substring(y * 8, 8))), 2);
                        }
                        //richTextBox1.Text += "C_16  " + x + "  " + C_16[x] + "\n";
                    }
                    for (int x = 0; x < 5; x++)
                    {
                        D_2[x] = XOR(C_2[positive(x - 1)], rotate(C_2[positive(x + 1)], "left", 1));
                        for (int y = 0; y < 8; y++)
                        {
                            D_16[x] += add_zero(DecToHex_SHA3(BinToDec(D_2[x].Substring(y * 8, 8))), 2);
                        }
                        //richTextBox1.Text += "D_2  " + x + "  " + D_2[x] + "\n";
                    }
                    for (int x = 0; x < 5; x++)
                    {
                        for (int y = 0; y < 5; y++)
                        {
                            xor_d_lanes_2[x, y] = XOR(xor_d_lanes_2[x, y], D_2[y]);
                            string tt = "";
                            for (int z = 0; z < 8; z++)
                            {
                                tt += add_zero(DecToHex_SHA3(BinToDec(xor_d_lanes_2[x, y].Substring(z * 8, 8))), 2);
                            }
                            xor_d_lanes_16[x, y] = tt;
                        }
                    }
                    /*for (int x = 0; x < 5; x++)
                    {
                        for (int y = 0; y < 5; y++)
                        {
                            //Вивести у вигляді таблички
                            //richTextBox2.Text += "[ " + x + " , " + y + " ] = " + xor_d_lanes[x, y] + "\n";
                        }
                    }*/
                    //richTextBox2.Text += "After ρ (Rho)" + "\n";
                    string[,] B_Rho_2 = new string[5, 5];
                    string[,] B_Rho_16 = new string[5, 5];
                    int[,] ro = new int[5, 5]
                    {
                    { 0, 36, 3, 41, 18 },
                    { 1, 44, 10, 45, 2 },
                    { 62, 6, 43, 15, 61 },
                    { 28, 55, 25, 21, 56 },
                    { 27, 20, 39, 8, 14 }
                    };
                    for (int x = 0; x < 5; x++)
                    {
                        for (int y = 0; y < 5; y++)
                        {
                            B_Rho_2[y, x] = rotate(xor_d_lanes_2[y, x], "left", ro[x, y]);
                            string tt = "";
                            for (int z = 0; z < 8; z++)
                            {
                                tt += add_zero(DecToHex_SHA3(BinToDec(B_Rho_2[y, x].Substring(z * 8, 8))), 2);
                            }
                            B_Rho_16[y, x] = tt;
                        }
                    }
                    /*for (int x = 0; x < 5; x++)
                    {
                        for (int y = 0; y < 5; y++)
                        {
                            //Вивести у вигляді таблички
                            //richTextBox2.Text += "[ " + x + " , " + y + " ] = " + B_Rho_16[x, y] + "\n";
                        }
                    }*/
                    //richTextBox2.Text += "After π (Pi)" + "\n";
                    string[,] B_Pi_2 = new string[5, 5];
                    string[,] B_Pi_16 = new string[5, 5];
                    for (int x = 0; x < 5; x++)
                    {
                        for (int y = 0; y < 5; y++)
                        {
                            B_Pi_2[y, (x * 2 + y * 3) % 5] = B_Rho_2[y, x];
                            string tt = "";
                            for (int z = 0; z < 8; z++)
                            {
                                tt += add_zero(DecToHex_SHA3(BinToDec(B_Pi_2[y, (x * 2 + y * 3) % 5].Substring(z * 8, 8))), 2);
                            }
                            B_Pi_16[(x * 2 + y * 3) % 5, y] = tt;
                        }
                    }
                    /*for (int x = 0; x < 5; x++)
                    {
                        for (int y = 0; y < 5; y++)
                        {
                            //Вивести у вигляді таблички
                            //richTextBox2.Text += "[ " + x + " , " + y + " ] = " + B_Pi_16[x, y] + "\n";
                        }
                    }*/
                    /*На всяк випадок. 2 кроки одначосно виконуються.
                     * richTextBox2.Text += "After ρ (Rho) and π (Pi)" + "\n";
                    string[,] B_2 = new string[5, 5];
                    string[,] B_16 = new string[5, 5];
                    int[,] ro = new int[5, 5]
                    {
                        { 0, 36, 3, 41, 18 },
                        { 1, 44, 10, 45, 2 },
                        { 62, 6, 43, 15, 61 },
                        { 28, 55, 25, 21, 56 },
                        { 27, 20, 39, 8, 14 }
                    };
                    for (int x = 0; x < 5; x++)
                    {
                        for (int y = 0; y < 5; y++)
                        {
                            B_2[y, (x * 2 + y * 3) % 5] = rotate(xor_d_lanes_bin[y, x], "left", ro[x, y]);
                            string tt = "";
                            for (int z = 0; z < 8; z++)
                            {
                                tt += add_zero(DecToHex_SHA3(BinToDec(B_2[y, (x * 2 + y * 3) % 5].Substring(z * 8, 8))), 2);
                            }
                            B_16[(x * 2 + y * 3) % 5, y] = tt;
                        }
                    }
                    for (int x = 0; x < 5; x++)
                    {
                        for (int y = 0; y < 5; y++)
                        {
                            //Вивести у вигляді таблички
                            richTextBox2.Text += "[ " + x + " , " + y + " ] = " + B_16[x, y] + "\n";
                        }
                    }*/
                    //richTextBox2.Text += "After χ (Chi)" + "\n";
                    for (int x = 0; x < 5; x++)
                    {
                        for (int y = 0; y < 5; y++)
                        {
                            xor_d_lanes_2[x, y] = XOR(B_Pi_2[y, x], AND(NOT(B_Pi_2[(y + 1) % 5, x]), B_Pi_2[(y + 2) % 5, x]));
                            string tt = "";
                            for (int z = 0; z < 8; z++)
                            {
                                tt += add_zero(DecToHex_SHA3(BinToDec(xor_d_lanes_2[x, y].Substring(z * 8, 8))), 2);
                            }
                            xor_d_lanes_16[x, y] = tt;
                        }
                    }
                    /*for (int x = 0; x < 5; x++)
                    {
                        for (int y = 0; y < 5; y++)
                        {
                            //Вивести у вигляді таблички
                            //richTextBox2.Text += "[ " + x + " , " + y + " ] = " + xor_d_lanes[x, y] + "\n";
                        }
                    }*/
                    string[] RC = new string[24]
                    {
                    "0000000000000001",
                    "0000000000008082",
                    "800000000000808A",
                    "8000000080008000",
                    "000000000000808B",
                    "0000000080000001",
                    "8000000080008081",
                    "8000000000008009",
                    "000000000000008A",
                    "0000000000000088",
                    "0000000080008009",
                    "000000008000000A",
                    "000000008000808B",
                    "800000000000008B",
                    "8000000000008089",
                    "8000000000008003",
                    "8000000000008002",
                    "8000000000000080",
                    "000000000000800A",
                    "800000008000000A",
                    "8000000080008081",
                    "8000000000008080",
                    "0000000080000001",
                    "8000000080008008"
                    };
                    //richTextBox2.Text += "After ι (Iota)" + "\n";
                    string t = "";
                    for (int y = 0; y < 8; y++)
                    {
                        string temp_0 = "", temp_1 = "";
                        temp_0 = RC[i].Substring(y * 2, 2);
                        temp_1 = xor_d_lanes_2[0, 0].Substring(y * 8, 8);
                        t += XOR(add_zero(DecToBin_SHA3(HexToDec_SHA3(temp_0)), 8), temp_1);
                    }
                    xor_d_lanes_2[0, 0] = t;
                    xor_d_lanes_16[0, 0] = "";
                    for (int z = 0; z < 8; z++)
                    {
                        xor_d_lanes_16[0, 0] += add_zero(DecToHex_SHA3(BinToDec(xor_d_lanes_2[0, 0].Substring(z * 8, 8))), 2);
                    }
                    /*for (int x = 0; x < 5; x++)
                    {
                        for (int y = 0; y < 5; y++)
                        {
                            //Вивести у вигляді таблички
                            //richTextBox2.Text += "[ " + x + " , " + y + " ] = " + xor_d_lanes[x, y] + "\n";
                        }
                    }*/
                    int temp = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        for (int y = 0; y < 5; y++)
                        {
                            for (int z = 7; z >= 0; z--)
                            {
                                state[temp] = xor_d_lanes_16[x, y].Substring(z * 2, 2);
                                temp++;
                            }
                        }
                    }
                }
                //richTextBox2.Text += "\n";
                //richTextBox2.Text += "After Permutation\n";
                /*for (int x = 0; x < 5; x++)
                {
                    for (int y = 0; y < 5; y++)
                    {
                        for (int z = 7; z >= 0; z--)
                            richTextBox2.Text += xor_d_lanes_16[x, y].Substring(z * 2, 2) + " ";
                    }
                }*/
                //richTextBox2.Text += "\n";
            }
            int result;
            result = c / 2 / 8;
            for (int x = 0; x < result; x++)
            {
                output += state[x];
                /*richTextBox2.Text += state[x] + " ";
                if (((x + 1) % 16) == 0)
                {
                    richTextBox2.Text += "\n";
                }*/
            }
            return output;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter the file path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string path = textBox1.Text;
                StreamReader stream = new StreamReader(path);
                string filedata = stream.ReadToEnd();
                text_input.Text = filedata.ToString();
                stream.Close();
            }
            //string path = @"D:\Навчання\КНТЕУ\Магістр\Project\test.txt";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = @"D:\Навчання\КНТЕУ\Магістр\Project";
            openFile.Title = "Browse Text Files Only";
            openFile.Filter = "Text Files Only (*.txt) | *.txt";
            openFile.DefaultExt = "txt";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                var fileLocation = File.ReadAllLines(openFile.FileName);
                textBox1.Text = openFile.FileName;
                richTextBox1.Clear();
                text_input.Clear();
            }
        }

        public int status;

        private void SHA2_224_CheckedChanged(object sender, EventArgs e)
        {
            status = 1;
            SHA3_224.Checked = false;
            SHA3_256.Checked = false;
            SHA3_384.Checked = false;
            SHA3_512.Checked = false;
            richTextBox1.Clear();
        }

        private void SHA2_256_CheckedChanged(object sender, EventArgs e)
        {
            status = 2;
            SHA3_224.Checked = false;
            SHA3_256.Checked = false;
            SHA3_384.Checked = false;
            SHA3_512.Checked = false;
            richTextBox1.Clear();
        }

        private void SHA2_384_CheckedChanged(object sender, EventArgs e)
        {
            status = 3;
            SHA3_224.Checked = false;
            SHA3_256.Checked = false;
            SHA3_384.Checked = false;
            SHA3_512.Checked = false;
            richTextBox1.Clear();
        }

        private void SHA2_512_CheckedChanged(object sender, EventArgs e)
        {
            status = 4;
            SHA3_224.Checked = false;
            SHA3_256.Checked = false;
            SHA3_384.Checked = false;
            SHA3_512.Checked = false;
            richTextBox1.Clear();
        }

        private void SHA2_512_224_CheckedChanged(object sender, EventArgs e)
        {
            status = 5;
            SHA3_224.Checked = false;
            SHA3_256.Checked = false;
            SHA3_384.Checked = false;
            SHA3_512.Checked = false;
            richTextBox1.Clear();
        }

        private void SHA2_512_256_CheckedChanged(object sender, EventArgs e)
        {
            status = 6;
            SHA3_224.Checked = false;
            SHA3_256.Checked = false;
            SHA3_384.Checked = false;
            SHA3_512.Checked = false;
            richTextBox1.Clear();
        }

        private void SHA3_224_CheckedChanged(object sender, EventArgs e)
        {
            status = 11;
            SHA2_224.Checked = false;
            SHA2_256.Checked = false;
            SHA2_384.Checked = false;
            SHA2_512.Checked = false;
            SHA2_512_224.Checked = false;
            SHA2_512_256.Checked = false;
            richTextBox1.Clear();
        }

        private void SHA3_256_CheckedChanged(object sender, EventArgs e)
        {
            status = 12;
            SHA2_224.Checked = false;
            SHA2_256.Checked = false;
            SHA2_384.Checked = false;
            SHA2_512.Checked = false;
            SHA2_512_224.Checked = false;
            SHA2_512_256.Checked = false;
            richTextBox1.Clear();
        }

        private void SHA3_384_CheckedChanged(object sender, EventArgs e)
        {
            status = 13;
            SHA2_224.Checked = false;
            SHA2_256.Checked = false;
            SHA2_384.Checked = false;
            SHA2_512.Checked = false;
            SHA2_512_224.Checked = false;
            SHA2_512_256.Checked = false;
            richTextBox1.Clear();
        }

        private void SHA3_512_CheckedChanged(object sender, EventArgs e)
        {
            status = 14;
            SHA2_224.Checked = false;
            SHA2_256.Checked = false;
            SHA2_384.Checked = false;
            SHA2_512.Checked = false;
            SHA2_512_224.Checked = false;
            SHA2_512_256.Checked = false;
            richTextBox1.Clear();
        }

        string plaintxt;
        string filename;
        string type;
        string db_hash;

        private void button_CalculateHASH_Click(object sender, EventArgs e)
        {
            if ((SHA2_224.Checked == true) || (SHA2_256.Checked == true) || (SHA2_384.Checked == true) || (SHA2_512.Checked == true) || (SHA2_512_224.Checked == true) || (SHA2_512_256.Checked == true) || (SHA3_224.Checked == true) || (SHA3_256.Checked == true) || (SHA3_384.Checked == true) || (SHA3_512.Checked == true))
            {
                string message = text_input.Text;
                string hash = "";
                //Вивести у глобальну змінну, оскільки буде перевірка файл або текстове поле.
                if (status < 10)
                {
                    string[] h_const = new string[8];
                    switch (status)
                    {
                        case 1:
                            string[] h_const_224 = new string[8] {
                                "11000001000001011001111011011000",
                                "00110110011111001101010100000111",
                                "00110000011100001101110100010111",
                                "11110111000011100101100100111001",
                                "11111111110000000000101100110001",
                                "01101000010110000001010100010001",
                                "01100100111110011000111110100111",
                                "10111110111110100100111110100100" };
                            hash = SHA_2_224_256(message, "hex", h_const_224, 224);
                            type = "SHA2 (224)";
                            break;
                        case 2:
                            string[] h_const_256 = new string[8] {
                                "01101010000010011110011001100111",
                                "10111011011001111010111010000101",
                                "00111100011011101111001101110010",
                                "10100101010011111111010100111010",
                                "01010001000011100101001001111111",
                                "10011011000001010110100010001100",
                                "00011111100000111101100110101011",
                                "01011011111000001100110100011001" };
                            hash = SHA_2_224_256(message, "hex", h_const_256, 256);
                            type = "SHA2 (256)";
                            break;
                        case 3:
                            /*string[] h_const_384 = new string[8] {
                                    "1100101110111011100111010101110111000001000001011001111011011000",
                                    "0110001010011010001010010010101000110110011111001101010100000111",
                                    "1001000101011001000000010101101000110000011100001101110100010111",
                                    "0001010100101111111011001101100011110111000011100101100100111001",
                                    "0110011100110011001001100110011111111111110000000000101100110001",
                                    "1000111010110100010010101000011101101000010110000001010100010001",
                                    "1101101100001100001011100000110101100100111110011000111110100111",
                                    "0100011110110101010010000001110110111110111110100100111110100100" };*/
                            hash = SHA_2_384(message, "hex");
                            type = "SHA2 (384)";
                            break;
                        case 4:
                            hash = Sha.Sha512(message).ToString();
                            type = "SHA2 (512)";
                            break;
                        case 5:
                            hash = Sha.Sha512_224(message).ToString();
                            type = "SHA2 (512/224)";
                            break;
                        case 6:
                            hash = Sha.Sha512_256(message).ToString();
                            type = "SHA2 (512/256)";
                            break;
                    }
                    if (lower_uppercase.Checked == true)
                    {
                        hash = hash.ToLower();
                    }
                    else
                    {
                        hash = hash.ToUpper();
                    }
                    richTextBox1.Text = hash + "\n";
                }
                else
                if (status > 10)
                {
                    int r = 0, c = 0;
                    switch (status)
                    {
                        case 11:
                            r = 1152;
                            c = 448;
                            type = "SHA3 (224)";
                            break;
                        case 12:
                            r = 1088;
                            c = 512;
                            type = "SHA3 (256)";
                            break;
                        case 13:
                            r = 832;
                            c = 768;
                            type = "SHA3 (384)";
                            break;
                        case 14:
                            r = 576;
                            c = 1024;
                            type = "SHA3 (512)";
                            break;
                    }
                    if (lower_uppercase.Checked == true)
                    {
                        richTextBox1.Text = SHA_3(message, r, c).ToLower();
                    }
                    else
                    {
                        richTextBox1.Text = SHA_3(message, r, c).ToUpper();
                    }
                }
                if (radioButton1.Checked == true)
                {
                    plaintxt = text_input.Text;
                    filename = "";
                }
                else
                {
                    filename = textBox1.Text;
                    plaintxt = text_input.Text;
                }
                db_hash = richTextBox1.Text;
            }
            else
            {
                MessageBox.Show("Please select the hash value output length.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            SHA2_224.Checked = false;
            SHA2_256.Checked = false;
            SHA2_384.Checked = false;
            SHA2_512.Checked = false;
            SHA2_512_224.Checked = false;
            SHA2_512_256.Checked = false;
            SHA3_224.Checked = false;
            SHA3_256.Checked = false;
            SHA3_384.Checked = false;
            SHA3_512.Checked = false;
            lower_uppercase.Checked = false;
            richTextBox1.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            //додати очищення результату
        }

        private string mssg960bin(string ms, int c)
        {
            string message_960 = ms;
            int b = (1024 * c) - ms.Length - 64;
            for (int i = 0; i < b; i++)
                message_960 += "0";
            return message_960;
        }

        private void cut_into_64_bit_data_segments(string[,] arr, string str, int c)
        {
            for (int i = 0; i < c; i++)
            {
                for (int y = 0; y < 80; y++)
                {
                    if ((y >= 0) && (y <= 15))
                    {
                        for (int z = 0; z < 64; z++)
                        {
                            arr[i, y] += str[z + 64 * y + 1024 * i];
                        }
                    }
                    else
                    {
                        for (int z = 0; z < 64; z++)
                        {
                            arr[i, y] += "0";
                        }
                    }
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                groupBox5.Enabled = true;
                text_input.Enabled = false;
                text_input.Clear();
                textBox1.Clear();
                richTextBox1.Clear();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                groupBox5.Enabled = false;
                text_input.Enabled = true;
                text_input.Clear();
                textBox1.Clear();
                richTextBox1.Clear();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string log = textBox4.Text;
            string pas = SHA_3(textBox5.Text, 1152, 448);
            if (textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Login or Password fields are empty", "LOG IN Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (checkUser(log, pas))
            {
                login = textBox4.Text;
                textBox4.Text = "";
                textBox5.Text = "";
                this.Width = 1000;
                label10.Text = login;
                groupBox_Login.Enabled = false;
                groupBox_Signup.Enabled = false;
            }
            else
            {
                textBox4.Text = "";
                textBox5.Text = "";
                CheckbxShowPas_log.Checked = false;
                textBox4.Focus();
                MessageBox.Show("Login or Password incorrect", "LOG IN Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool checkUser(string text_l, string text_p)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-0BAUFHT\SQLEXPRESS; Initial Catalog = HASH_calculator; User ID = sa ; Password = KAV120181r");
            con.Open();
            string query = "SELECT login, password FROM Users WHERE login = '" + text_l + "' and password = '" + text_p + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
                result = true;
            con.Close();
            return result;
        }

        string login = "";

        private void button_saveHASH_Click(object sender, EventArgs e)
        {
            if (login == "")
            {
                MessageBox.Show("Please login to save HASH.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-0BAUFHT\SQLEXPRESS; Initial Catalog = HASH_calculator; User ID = sa ; Password = KAV120181r");
                con.Open();
                string query = @"INSERT INTO HASH_table 
                                 VALUES
                                 ((Select id_user from Users where login='" + login + "'), '" + filename + "', '" + plaintxt + "', '" + type + "', '" + db_hash + "', GETDATE())";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("The data is entered successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void clear_login_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox5.Text = "";
            CheckbxShowPas_log.Checked = false;
        }

        private void CheckbxShowPas_log_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckbxShowPas_log.Checked)
            {
                textBox5.PasswordChar = '\0';
            }
            else
            {
                textBox5.PasswordChar = 'x';
            }
        }

        private void CheckbxShowPas_sign_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckbxShowPas_sign.Checked)
            {
                textBox7.PasswordChar = '\0';
                textBox8.PasswordChar = '\0';
            }
            else
            {
                textBox7.PasswordChar = 'x';
                textBox8.PasswordChar = 'x';
            }
        }

        private void clear_signup_Click(object sender, EventArgs e)
        {
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            CheckbxShowPas_sign.Checked = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox6.Text != "" && (textBox7.Text == "" || textBox8.Text == ""))
            {
                MessageBox.Show("Password fields are empty", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox7.Focus();
            }
            else if (textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "")
            {
                MessageBox.Show("Login or Password fields are empty", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox7.Text == textBox8.Text)
            {
                bool check = checkLogin(textBox6.Text);
                if (check)
                {
                    SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-0BAUFHT\SQLEXPRESS; Initial Catalog = HASH_calculator; User ID = sa ; Password = KAV120181r");
                    con.Open();
                    string query = "INSERT INTO Users(login, password) VALUES ('" + textBox6.Text + "', '" + SHA_3(textBox7.Text, 1152, 448) + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("A user has been created", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    CheckbxShowPas_sign.Checked = false;
                }
                else
                {
                    MessageBox.Show("A user with this name already exists, Please Re-enter", "Registration Failed, Incorrect username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Password does not match, Please Re-enter", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox7.Focus();
            }
        }

        private bool checkLogin(string login)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-0BAUFHT\SQLEXPRESS; Initial Catalog = HASH_calculator; User ID = sa ; Password = KAV120181r");
            con.Open();
            string query = "SELECT login FROM Users WHERE login = '" + login + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            if (!dr.HasRows)
            {
                result = true;
            }
            con.Close();
            return result;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (login != "")
            {
                richTextBox3.Text = "";
                SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-0BAUFHT\SQLEXPRESS; Initial Catalog = HASH_calculator; User ID = sa ; Password = KAV120181r");
                con.Open();
                string query = @"SELECT plaintxt, type, hash
                                 FROM HASH_table a
                                 JOIN Users b
                                 ON a.id_user = b.id_user
                                 WHERE b.login = '" + login + "';";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    richTextBox3.Text += dr["type"].ToString();
                    richTextBox3.Text += " - ";
                    richTextBox3.Text += dr["plaintxt"].ToString();
                    richTextBox3.Text += " - ";
                    richTextBox3.Text += dr["hash"].ToString();
                    richTextBox3.Text += "\n";
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Can`t view saved HASHes when user not Log In.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 784;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            login = "";
            richTextBox3.Text = "";
            this.Width = 784;
            groupBox_Login.Enabled = true;
            groupBox_Signup.Enabled = true;
        }

        private void clear_savedHASH_Click(object sender, EventArgs e)
        {
            richTextBox3.Text = "";
        }
    }
}