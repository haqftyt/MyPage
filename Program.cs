using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDetailsManagement
{
    class Student //student Model
    {

        private int Id;
        private string Name;
        private int age ;
        private float percentage;
        private string courseName;
     public  Student(int Id,string Name,int age,float percentage,string courseName)
        {
            this.Id = Id;
            this.age = age;
            this.percentage = percentage;
            this.courseName = courseName;
            this.Name = Name;
        }
        public int getId()
        {
            return Id;
        }
        public string getName()
        {
            return Name;

        }
        public int getAge()
        {
            return age;

        }
        public float getPercentage()
        {
            return percentage;
        }
        public string getCourseName()
        {
                return courseName;
        }
        //set methods
        public void setName(string Name)
        {
            this.Name = Name;
        }
        public void setAge(int age)
        {
            this.age = age;
        }
        public void setpercentage(float percentage)
        {
            this.percentage = percentage;
        }
        public void setCourse(string courseName)
        {
            this.courseName = courseName;
        }
    }
    class StudentManagement
    {
        public List<Student> students=new List<Student>();
        public int Id = 1000;
        public Student storeDetails(string name,int age,float percentage,string courseName)
        {
            Student student=new Student(Id++,name,age,percentage,courseName);
            students.Add(student);
            Console.WriteLine("Record Added Successfully.....");
            return student;
        }
        public void viewDetails()
        {
            Console.WriteLine("--------------------------------------------------------------------------------------------");
            Console.WriteLine("ID\t\tNAME\t\t\tAGE\t\t\tPERCENTAGE\t\tCOURSENAME");
            foreach (Student s in students)
            { 
                Console.Write(s.getId() +"\t    "+s.getName()+"\t\t         " +s.getAge()+"\t\t         "+s.getPercentage()+"\t\t         "+s.getCourseName()+"\n");
            }
            Console.WriteLine("--------------------------------------------------------------------------------------------");
        }
       public Student getDetailsById(int Id)
        {
            foreach(Student n in students)
            {
                if (n.getId() == Id)
                {
                    return n;
                }
            }
            return null;
        }
        public Boolean DeleteRecordById(int Id)
        {
            Student s = getDetailsById(Id);
            if (s != null)
            {
                students.Remove(s);
                Console.WriteLine("Record Deleted Successfully....");
                return true;
            }
            else
            {
                Console.WriteLine("Record not found");
                return false;
            }
            
        }
        public void EditDetailsById(int Id)
        {
            
            foreach(Student s in students)
            {
                if (s.getId() == Id)
                {
                    Console.WriteLine("Which you want to Update ?");
                    Console.WriteLine("\n1.Edit Name\n2.Edit Age\n3.Edit Percentage\n4.Edit course");
                    int edit = Convert.ToInt32(Console.ReadLine());
                    switch (edit)
                    {
                        case 1:
                            Console.WriteLine("Enter the New Name:");
                            string Newname = Console.ReadLine();
                            s.setName(Newname);
                            break;
                        case 2:
                            Console.WriteLine("Enter the New Age:");
                            int newage = Convert.ToInt32(Console.ReadLine());
                            s.setAge(newage);
                            break;
                        case 3:
                            Console.WriteLine("Enter the New Percentage:");
                            float newpercent = Convert.ToSingle(Console.ReadLine());
                            s.setpercentage(newpercent);
                            break;
                        case 4:
                            Console.WriteLine("Enter the New Course:");
                            string newCourse = Console.ReadLine();
                            s.setCourse(newCourse);
                            break;
                        
                    }
                    Console.WriteLine("Record Updated Successfully.....");
                }
            }
        }

    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            int condition = 1;
            StudentManagement studentManagement = new StudentManagement();
            while (condition == 1)
            {
                Console.WriteLine("================Student Management System================= ");
                Console.WriteLine("\n\t\t1.Add Student Details\n\t\t2.View Student Details\n\t\t3.Delete Student Details\n\t\t4.Edit Student Details\n\t\t5.Exit");
                Console.WriteLine("Please Enter your option:");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                Console.Beep();
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter your Name:");
                        string name=Console.ReadLine();
                        Console.WriteLine("Enter your age:");
                        int age = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter your percentage:");
                        float percentage= Convert.ToSingle(Console.ReadLine());
                        Console.WriteLine("Enter your Course:");
                        string courseName=Console.ReadLine(); 
                        studentManagement.storeDetails(name,age,percentage,courseName);
                        break;
                    case 2:
                        studentManagement.viewDetails();
                        break;
                    case 3:
                        Console.WriteLine("Enter the Id to Delete:");
                        int Id = Convert.ToInt32(Console.ReadLine());
                        studentManagement.DeleteRecordById(Id);
                        break;
                    case 4:
                        Console.WriteLine("Enter the Id to Edit:");
                        int id = Convert.ToInt32(Console.ReadLine());
                        studentManagement.EditDetailsById(id);
                        break;
                    case 5:
                        condition = 0; 
                        break;
                }
            }
        }
    }
}
