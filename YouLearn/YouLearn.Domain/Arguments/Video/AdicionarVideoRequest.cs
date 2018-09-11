using System;

namespace YouLearn.Domain.Arguments.Video
{
    public class AdicionarVideoRequest
    {
        public Guid Id { get; set; }
        public Guid IdPlayList { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Tags { get; set; }
        public int? OrdemPlayList { get; set; }
        public string IdVideoYoutube { get; set; }
        public Guid IdCanal { get; set; }
    }
}
