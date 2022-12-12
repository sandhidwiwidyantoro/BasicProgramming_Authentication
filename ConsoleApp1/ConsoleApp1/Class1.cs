using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    class Class1
    {
        public static List<Users> arrUsers = new List<Users>();

        static void Main(string[] args)
        {

        Start:
            Console.Clear();
            Console.WriteLine("Nama Kelompok 2 : ");
            Console.WriteLine(" Sandhi Dwi Widyantoro ");
            Console.WriteLine(" Calvin Moyana");
            Console.WriteLine("==BASIC AUTHENTICATION==");
            Console.WriteLine("1. Create User");
            Console.WriteLine("2. Show User");
            Console.WriteLine("3. Search User");
            Console.WriteLine("4. Login User");
            Console.WriteLine("5. Exit");
            Console.Write("Masukkan Pilihan : ");
            var input = Console.ReadLine();

            bool successfull = false;
            while (!successfull)
            {
                if (input == "1")
                {
                    menuRegistrasi();
                    string enterin = Console.ReadLine();
                    goto Start;
                }
                else if (input == "2")
                {
                    showUser();
                    menuEditUbahHapus(input);
                    string enterin = Console.ReadLine();
                    goto Start;
                }
                else if (input == "3")
                {
                    cariAkun();
                    string enterin = Console.ReadLine();
                    goto Start;
                }
                else if (input == "4")
                {
                    login();
                    string enterin = Console.ReadLine();
                    goto Start;
                }
                else if (input == "5")
                {
                    successfull = true;
                }
                else
                {
                    Console.WriteLine("Try again !!!");
                    string enterin = Console.ReadLine();
                    goto Start;
                }

            }

        }
        public static void menuRegistrasi()
        {

            Boolean a = true;
            Console.Clear();
            Console.Write("Enter your first name: ");
            var first_name = Console.ReadLine();

            Console.Write("Enter your last name: ");
            var last_name = Console.ReadLine();

            Regex validateGuidRegex = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$");
            var password = "";
            do
            {
                Console.Write("Enter your password: ");
                password = Console.ReadLine();

                if(!validateGuidRegex.IsMatch(password))
                {
                    Console.WriteLine("Password must have at least 8 characters\r\n with at least one Capital letter, at least one lower case letter and at least one number.");
                }
            } while (!validateGuidRegex.IsMatch(password));

            if (validateGuidRegex.IsMatch(password))
            {
                for (int i = 0; i < arrUsers.Count; i++)
                {
                    if (arrUsers[i].username.ToLower().Equals(first_name.Substring(0, 2) + last_name.Substring(0, 2)))
                    {
                        Console.WriteLine("Create Failure, Username already exits!!!");
                        string enterin = Console.ReadLine();
                        a = false;
                        break;
                    }
                }
                if (a)
                {
                    arrUsers.Add(new Users(first_name, last_name, first_name.Substring(0, 2) + last_name.Substring(0, 2), password));
                    Console.WriteLine("User Success to Created !!!");
                }
            }
        }
        public static void showUser()
        {
            Console.Clear();
            Console.WriteLine("== SHOW USER ==");
            for (int i = 0; i < arrUsers.Count; i++)
            {
                Console.WriteLine("=============================");
                Console.WriteLine("ID\t: "+(i+1));
                Console.WriteLine("Name\t: "+ arrUsers[i].first_name + " " + arrUsers[i].last_name);
                Console.WriteLine("Username: "+ arrUsers[i].username);
                Console.WriteLine("Password: "+ arrUsers[i].password);
                Console.WriteLine("=============================");
            }
        }
        public static void menuEditUbahHapus(string input) 
        {
            Console.WriteLine("Menu : ");
            Console.WriteLine("1. Edit user");
            Console.WriteLine("2. Delete user");
            Console.WriteLine("3. Back");
            input = Console.ReadLine();

            if (input == "1")
            {
                Console.Write("Id yang ingin diubah = ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Write("First name = ");
                arrUsers[id - 1].first_name = Console.ReadLine();
                Console.Write("Last name = ");
                arrUsers[id - 1].last_name = Console.ReadLine();
                arrUsers[id - 1].username = arrUsers[id-1].first_name.Substring(0, 2) + arrUsers[id - 1].last_name.Substring(0, 2);
                Console.Write("password = ");
                arrUsers[id - 1].password = Console.ReadLine();
                Console.WriteLine("User Success to Edited!!!");
                string enterin = Console.ReadLine();
            }
            else if (input == "2")
            {
                Console.Write("Id yang ingin dihapus = ");
                int i = Convert.ToInt32(Console.ReadLine());
                arrUsers.RemoveAt(i - 1);
                Console.WriteLine("User Success to Deleted!!!");
                string enterin = Console.ReadLine();
            }
        }

        public static void cariAkun()
        {
            Console.Clear();
            Console.WriteLine("==Cari Akun==");
            Console.Write("Masukkan nama : ");
            string name = Console.ReadLine().ToLower();
            for (int i = 0; i < arrUsers.Count; i++)
            {
                if (arrUsers[i].first_name.ToLower().Equals(name) || arrUsers[i].last_name.ToLower().Equals(name))
                {
                    Console.WriteLine("=============================");
                    Console.WriteLine("ID\t: " + (i + 1));
                    Console.WriteLine("Name\t: " + arrUsers[i].first_name + " " + arrUsers[i].last_name);
                    Console.WriteLine("Username: " + arrUsers[i].username);
                    Console.WriteLine("Password: " + arrUsers[i].password);
                    Console.WriteLine("=============================");
                }
            }
        }

        public static void login()
        {
            Boolean b = true;
            Console.Clear();
            Console.WriteLine("==LOGIN==");
            Console.Write("Write your username: ");
            string usernme = Console.ReadLine();
            Console.Write("Enter your password: ");
            string pssword = Console.ReadLine();

            for (int i = 0; i < arrUsers.Count; i++)
            {
                if (arrUsers[i].username.Equals(usernme) && arrUsers[i].password.Equals(pssword))
                {
                    Console.WriteLine("MESSAGE : Login Berhasil !!!\n");
                    b = false;
                    break;
                }
            }
            if (b)
            {
                Console.WriteLine("Username atau Password tidak ditemukan !!!\n");
            }
        }
    }

    public class Users
    {
        public string first_name;
        public string last_name;
        public string username;
        public string password;

        public Users(string first_name, string last_name,string username, string password)
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.username = username;
            this.password = password;
        }
    }
}
