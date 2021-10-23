using System;
using System.Collections.Generic;
using  EFCoreDBFirstMastek.Models;
using System.Linq;

namespace EFCoreDBFirstMastek
{
    class Program
    {
        static void Main(string[] args)
        {
            TrainingContext db = new TrainingContext();

            //IEnumerable<Emp> query1 = from e in db.Emps select e;
            //foreach( Emp item in query1)
            //{
            //Console.WriteLine(item.Ename + " " + item.Job + " " + item.Sal + " " +  item.Deptno);
            //}

            //Console.WriteLine("-----------------");
            /* IEnumerable<Dept> query2 = db.Depts.ToList();
             foreach ( Dept item in query2)
             {
               Console.WriteLine(item.Deptno + " " + item.Dname + " " + item.Loc);
             }

             //1 list emp working in dept 10 as manager
             IEnumerable<Emp> query3 = from e in db.Emps where e.Deptno == 10 && e.Job == "manager" select e;
             foreach(Emp item  in query3)
             {
                 Console.WriteLine(item.Job + " " + item.Deptno);
             }
             Console.WriteLine("-----------------------");
             //2 list empname, job, deptno for all emps working as clerk

             IEnumerable<Emp> query4 = from e in db.Emps where e.Job == "clerk" select e;
                 //query4 = db.Emps.Where(e => e.Job == "clerk").Select(e => new { e.Ename, e.Job, e.Deptno });*/

            //listing all emp as per job
            //var query5 = from e in db.Emps orderby e.Job select e;
            //query5 = db.Emps.OrderBy(e => e.Job);

            //desecding order 
            //listing all ep as per salary H to L
            //query5 = from e in db.Emps.OrderByDescending(e => e.Sal);
            //query5 = from e in db.Emps orderby e.Deptno, e.Sal descending select e;
            //query5 = db.Emps.OrderBy(e => e.Deptno).ThenByDescending(e => e.Sal);

            //foreach (var item in query5)
            //{

            //  string job = item.Job;
            //if (job == null)
            //{
            //  job = " ";
            //}

            //  Console.WriteLine(item.Ename.PadRight(25 )+ " " + item.Job + " " + item.Deptno + " " + item.Sal);
            //}

            //joins
            // list empname, job, sal, deptname, loc
            /*var query6 = from e in db.Emps
                         join d in db.Depts on e.Deptno equals d.Deptno
                         orderby d.Dname
                         select new { e.Ename, e.Job, e.Sal, d.Dname, d.Loc };
            // metod syntax
            query6 = db.Emps.Join(db.Depts, e => e.Deptno, d => d.Deptno, (e, d) => new { e.Ename, e.Job, e.Sal, d.Dname, d.Loc });

            // left join

            query6= from e in db.Emps
                    join d in db.Depts on e.Deptno equals d.Deptno
                    into empdept from d in empdept.DefaultIfEmpty()
                    select new { e.Ename, e.Job, e.Sal, d.Dname, d.Loc };

            foreach ( var item in query6)
            {
                Console.WriteLine(item.Ename.PadRight(25) + " " + item.Job + "                   " + item.Sal.ToString().PadRight(12) + item.Dname + "               " + item.Loc);
            }*/

            //total salary of organization
            //var query7 = (from e in db.Emps select e).Sum(e => e.Sal);
            //query7 = db.Emps.Sum(e => e.Sal);
            //Console.WriteLine("Total Sal = " + query7);


            //insert

            // Console.WriteLine("total emp records = " + db.Emps.Count());

            //Emp newEmp = new Emp() { Empno = 101, Ename = "naveen", Job = "Manager", Sal = 20000, Deptno = 10 };
            //db.Emps.Add(newEmp);  // add new record into in memory collection
            //int count = db.SaveChanges();
            //if ( count == 1)
            //{
            //  Console.WriteLine("\n ----------record insaerted------------------\n");
            //}

            //Console.WriteLine("total emp records = " + db.Emps.Count());

            //edit or modify

            // Emp editEmp = db.Emps.SingleOrDefault(e => e.Empno == 101);
            //if (editEmp != null)
            //{
            //  editEmp.Ename = "amit";
            // editEmp.Sal = 3000;
            //}



            //int count = db.SaveChanges();
            //if (count == 1)
            //{
            //  Console.WriteLine("\n-----------record modified-----------\n");
            //}



            //delete


            Emp oldEmp = db.Emps.SingleOrDefault(e => e.Empno == 101);
            if ( oldEmp != null)
            {
                db.Emps.Remove(oldEmp);  //remove from in memroy collection
                int count = db.SaveChanges();
                if (count == 1)
                {
                    Console.WriteLine("\n-------------------record Deleted--------------------\n");

                }
            }
            else
            {
                Console.WriteLine($"Emp with no 101 not found");
            }


            TrainingContext db1 = new TrainingContext();
            string username = "admin";
            string pwd = "123";

            Userdatum user = db.Userdata.SingleOrDefault(u => u.Username == username && u.Password == pwd);
        }
    }
}
