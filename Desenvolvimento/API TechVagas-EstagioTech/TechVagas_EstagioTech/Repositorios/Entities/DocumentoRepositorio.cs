﻿using Microsoft.EntityFrameworkCore;
using TechVagas_EstagioTech.Data;
using TechVagas_EstagioTech.Objects.Model.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;

namespace TechVagas_EstagioTech.Repositorios
{
    public class DocumentoRepositorio : IDocumentoRepositorio
    {
        private readonly DBContext _dbContext;
        public DocumentoRepositorio(DBContext documentoDBContex)
        {
            _dbContext = documentoDBContex;
        }

        public async Task<List<DocumentoModel>> BuscarPorContrato(int idContrato)
        {
            return await _dbContext.Documento.Where(x => x.idContratoEstagio == idContrato).ToListAsync();
        }

        public async Task<DocumentoModel> BuscarPorId(int id)
        {
			return await _dbContext.Documento.Where(x => x.idDocumento == id).FirstOrDefaultAsync();
		}

        public async Task<List<DocumentoModel>> BuscarTodosDocumentos()
        {
            return await _dbContext.Documento.ToListAsync();
        }

        public async Task<DocumentoModel> Adicionar(DocumentoModel documentoModel)
        {
			_dbContext.Documento.Add(documentoModel);
			await _dbContext.SaveChangesAsync();
			return documentoModel;
		}

        public async Task<DocumentoModel> Atualizar(DocumentoModel documentoModel)
        {
            var EditedObj = _dbContext
                    .Documento.Where(x => x.idDocumento == documentoModel.idDocumento)
                    .First();
            _dbContext.Entry(EditedObj).CurrentValues.SetValues(documentoModel);
			await _dbContext.SaveChangesAsync();
			return documentoModel;

		}

        public async Task<bool> Apagar(int id)
        {
			var documento = await BuscarPorId(id);
			_dbContext.Documento.Remove(documento);
			await _dbContext.SaveChangesAsync();
			return true;
		}      
    }
}
