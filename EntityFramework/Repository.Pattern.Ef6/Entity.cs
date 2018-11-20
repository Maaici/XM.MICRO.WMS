using System.ComponentModel.DataAnnotations.Schema;
using Repository.Pattern.Infrastructure;
using System;

namespace Repository.Pattern.Ef6
{
    [Serializable]
    public abstract class Entity : IObjectState
    {
        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}