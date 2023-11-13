﻿using TechVagas_EstagioTech.Dtos.Entities;

namespace TechVagas_EstagioTech.Services.Interfaces
{
    public interface IDocumentoVersaoService
    {
        Task<IEnumerable<DocumentoVersaoDto>> BuscarTodosTipoDocumentos();
        Task<DocumentoVersaoDto> BuscarPorId(int id);
        Task Adicionar(string comentario);
        Task Atualizar(DocumentoVersaoDto documentoVersaoDto);
        Task Apagar(int id);
    }
}
