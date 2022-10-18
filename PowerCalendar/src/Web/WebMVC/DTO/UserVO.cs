using System.Collections.Generic;
using System;

namespace WebMVC.DTO
{
    public class UserVO
    {
        public long Code { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public UserStatusType Status { get; set; }
        public DateTime Register { get; set; }
        public List<RoleVO> Roles { get; set; }
        public UserVO()
        {
            this.Roles = new List<RoleVO>();
        }
    }
}
