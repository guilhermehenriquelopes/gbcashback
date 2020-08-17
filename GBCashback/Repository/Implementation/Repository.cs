using GBCashback.Models.Base;
using GBCashback.Repository.Interface;
using GBCashback.Util;
using System;
using System.Collections.Generic;

namespace GBCashback.Repository.Implementation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private readonly DatabaseContext _context;

        public Repository(DatabaseContext context)
        {
            _context = context;
        }

        public TEntity Atualizar(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(Cadastrar)} " + Mensagens.EntidadeNaoPodeSerNula);
            }

            try
            {
                _context.Update(entity);
                _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} " + Mensagens.EntidadeNaoPodeSerSalva + " - Error: " + ex.Message);
            }
        }

        public TEntity Cadastrar(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(Cadastrar)} " + Mensagens.EntidadeNaoPodeSerNula);
            }

            try
            {
                _context.Set<TEntity>().Add(entity);
                _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} " + Mensagens.EntidadeNaoPodeSerSalva + " - Error: " + ex.Message);
            }
        }

        public IEnumerable<TEntity> Consultar()
        {
            try
            {
                return _context.Set<TEntity>();
            }
            catch (Exception)
            {
                throw new Exception(Mensagens.NenhumRegistroEncontrado);
            }
        }

        public TEntity Consultar(long id)
        {
            try
            {
                return _context.Set<TEntity>().Find(id);
            }
            catch (Exception)
            {
                throw new Exception(Mensagens.NenhumRegistroEncontrado);
            }
        }

        public TEntity Deletar(long id)
        {
            var entity = _context.Set<TEntity>().Find(id);

            try
            {
                _context.Remove(entity);
                _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} " + Mensagens.EntidadeNaoPodeSerSalva + " - Error: " + ex.Message);
            }
        }
    }
}