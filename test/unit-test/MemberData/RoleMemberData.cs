using System;
using System.Collections;
using System.Collections.Generic;
using test.DTOs;

namespace unit_test.MemberData
{
    public class RoleMemberData
    {
        public static IEnumerable<object[]> AddRole()
        {
            RoleToAddDTO role = new RoleToAddDTO()
            {
                RoleKey = "admin",
                RoleName = "Admin"
            };    

            yield return new object[] { role };
        }

        public static IEnumerable<object[]> GetById()
        {
            yield return new object[] { 1 };
        }
    }
}
