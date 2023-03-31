using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flunt.Notifications;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace IdentidadeCultural.Compartilhado.Dominio.Entidades
{

    public class Entidade : Notifiable<Notification>
    {
        public Guid Id { get; init; }
        public Entidade() => Id = Guid.NewGuid();
        [NotMapped]
        public virtual bool PodeEditar => false;
        protected string Serializar()
            => JsonSerializer.Serialize<object>(this, new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                WriteIndented = true,
                IgnoreNullValues = true
            });
    }
}