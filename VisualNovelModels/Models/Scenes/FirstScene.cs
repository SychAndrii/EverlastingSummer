using ConsoleTesting.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelModels.Models.Scenes
{
    public class FirstScene
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public bool Id { get; set; } = true;
        public Scene? Scene { get; set; }
    }
}
