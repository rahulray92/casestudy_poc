using PMT_DAL.Interface;
using PMT_DAL.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMT_BAL.Service
{
    public class MemberService
    {
        private readonly IRepository<Member> _member;
          public MemberService(IRepository<Member> member)
        {
            _member = member;
        }
        //Get Person Details By Person Id  
        //public IEnumerable<Member> GetMemberByUserId(string UserId)
        //{
        //    return _member.GetAll().Where(x => x.UserEmail == UserId).ToList();
        //}
        //GET All Perso Details   
        public IEnumerable<Member> GetAllMembers(Member newMembers)
        {
            try
            {
                var data = _member.GetAll(newMembers).ToList();
                var sortdata=data.OrderByDescending(m => m.YearOfExp).ToList();
                
                return sortdata;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        //Add new Member  
        public async Task<Member> AddNewMembers(Member members)
        {
            try
            {
                var val = new Member();
                
                var validationMsg = Valdation(members);
                if (validationMsg != string.Empty)
                {
                    throw new Exception(validationMsg);
                    //return val;
                }
                else
                    return await _member.AddNewMember(members);
            }
            catch (Exception)
            {
                throw;
            }
        }
       
        //Update percentage Details  
        public bool UpdateAllocationPercentage(Member member)
        {
            try
            {
                DateTime d2;
               
              
                var DataList = _member.GetAll(member).Where(x => x.IsDeleted != true && x.MemberId== member.MemberId).ToList();
                foreach (var item in DataList)
                {
                    d2 = DateTime.Parse(item.ProjectendDate, new CultureInfo("en-US", true));
                    DateTime currentDate = DateTime.Now;
                    if (d2 < currentDate)
                        item.AllocationPercentage = "0";
                    else
                        item.AllocationPercentage = "100";

                     
                    _member.Update(item);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

        private string Valdation(Member item)
        {
            DateTime d1, d2;
            d1 = Convert.ToDateTime(item.ProjectstartDate, System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat);
            //d1 = DateTime.Parse(item.ProjectstartDate, new CultureInfo("en-US",true));
            d2 = DateTime.Parse(item.ProjectendDate, new CultureInfo("en-US", true));
            string msg = string.Empty;
            if (item.YearOfExp <= 4)
                msg = "Exp should be greater than 4 years";
            if (item.SkillSet.Split(',').Length <3)
                msg = "Skill should be greater than 2";
            if (d2.Date <= d1.Date)
                msg = "Project end date should be greater than project start date";
            if (!(Convert.ToInt32(item.AllocationPercentage)<=100 && Convert.ToInt32(item.AllocationPercentage) >=0))
                msg = "Allocation should be provided as percentage";

            return msg;
        }
    
        

    }
}
