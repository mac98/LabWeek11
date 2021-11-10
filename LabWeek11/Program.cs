using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWeek11
{
    class Program
    {
        static void Main(string[] args)
        {
            Email email1 = new Email();
            email1.WriteToDocument("Hello, How are you?");
            email1.Sender = "Jim Darkins";
            email1.Recipient = "Ivory Jones";
            email1.Title = "Welcome Back";

            Email email2 = new Email();
            email2.WriteToDocument("Who the heck are you? How did you get this address?");
            email2.Sender = "Ivory Jones";
            email2.Recipient = "Jim Darkins";
            email2.Title = "RE:Welcome Back";

            File trip_summary = new File();
            trip_summary.Path_Name = "Documents/Vacation_Blogs/Spain/08-19-1992";
            trip_summary.WriteToDocument("Just visited Madrid. Very large. Having fun. Will write more later. Sad to go home.");

            File email_tracker = new File();
            email_tracker.Path_Name = "Documents/Investigation/Creepy_Emails/Sum_Log";
            email_tracker.WriteToDocument("08-24-92: Jim Darkins\n08-25-92: Jim Darkins\n08-25-92: Jim Darkins\n08-26-92: Jim Darkins\n08-27-92: Jim Darkins\n");

            Console.WriteLine(ContainsKeyword(email1, "Darkins"));
            Console.WriteLine(ContainsKeyword(email2, "RE:"));
            Console.WriteLine(ContainsKeyword(trip_summary, "Madrid"));
            Console.WriteLine(ContainsKeyword(email_tracker, "Jim"));
            
            Console.Read();
        }

        public static bool ContainsKeyword(Document docObject, string keyword)
        {
            if (docObject.ToString().IndexOf(keyword, 0) >= 0)
                return true;
            return false;
        }
    }

    class Document
    {
        string text;

        public void WriteToDocument(string _text)
        {
            text = _text;
        }

        public override string ToString()
        {
            return text;
        }
    }

    class Email : Document
    {
        string sender, recipient, title;

        public string Sender { get { return sender; } set { sender = value; } }
        public string Recipient { get { return recipient; } set { recipient = value; } }
        public string Title { get { return title; } set { title = value; } }

        public override string ToString()
        {
            return "From: " + sender + "\nTo: " + recipient + "\n" + Title + "\n" + base.ToString();
        }
    }

    class File : Document
    {
        string path_name;

        public string Path_Name { get { return path_name; } set { path_name = value; } }

        public override string ToString()
        {
            return path_name + "\n" + base.ToString();
        }
    }
}
