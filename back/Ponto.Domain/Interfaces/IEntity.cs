using FluentValidator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ponto.Domain.Interfaces
{
    public interface IEntity
    {
        Guid Id { get; set; }
        bool Valid { get; }
        bool Invalid { get; }
    }
}
