using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using FluentValidator;
using Ponto.Domain.Interfaces;

namespace Ponto.Domain.Models
{
    public abstract class Entity : Notifiable, IEntity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
    }
}
