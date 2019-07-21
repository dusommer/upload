﻿using Upload.Domain.Entities.Base;
using System;

namespace Upload.Domain.Entities
{
    public class File : EntityBase
    {
        public File()
        {
        }

        public File(string name, decimal size, int idUser, DateTime createdDate)
        {
            Name = name;
            Size = size;
            IdUser = idUser;
            CreatedDate = createdDate;
        }

        public string Name { get; private set; }
        public decimal Size { get; private set; }
        public int IdUser { get; private set; }
        public DateTime CreatedDate { get; private set; }

        public virtual User User { get; set; }

        public override void Validate()
        {

        }
    }
}
