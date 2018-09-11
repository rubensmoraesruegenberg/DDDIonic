using System;
using YouLearn.Domain.Entities;

namespace YouLearn.Domain.Arguments.Video
{
    public class VideoResponse
    {
        public string NomeCanal { get; set; }
        public Guid? IdPlayList { get; set; }
        public string NomePlayList { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string ThumbNail { get; set; }
        public string IdVideoDoYoutube { get; set; }
        public int? OrdemNaPlayList { get; set; }
        public string Url { get; set; }

        public static explicit operator VideoResponse(Entities.Video entidade)
        {
            return new VideoResponse() {
                Descricao = entidade.Descricao,
                Url = string.Concat("https://www.youtube.com/embed/", entidade.IdVideoYouTube),
                NomeCanal = entidade.Canal.Nome,
                IdVideoDoYoutube = entidade.IdVideoYouTube,
                ThumbNail = string.Concat("http://img.youtube.com/vi", entidade.IdVideoYouTube, "mqdefault.jpg"),
                Titulo = entidade.Titulo,
                IdPlayList = entidade.PlayList?.Id,
                NomePlayList = entidade.PlayList?.Nome,
                OrdemNaPlayList = entidade.OrdemNaPlayList
            };
        }
    }
}
