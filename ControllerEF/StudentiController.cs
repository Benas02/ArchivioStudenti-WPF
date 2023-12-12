using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDemo.Model;
using WPFDemo.ModelEF;

namespace WPFDemo.ControllerEF
{
    internal class StudentiController
    {
        #region "Studente Random"
        public static async Task<Studenti> GetRandomStudent()
        {
            Random random = new Random();

            using (StudentiContext context = new StudentiContext())
            {
                var MaxId = await context.Studenti.MaxAsync(max => max.IdStudente);
                var MinId = await context.Studenti.MinAsync(min => min.IdStudente);

                while (true)
                {
                    int idRandom = random.Next(MinId, MaxId);
                    Studenti studenti = await context.Studenti.FirstOrDefaultAsync(id => id.IdStudente == idRandom);

                    if (studenti != null)
                    {
                        return studenti;
                    }
                }             
            }
        }
        #endregion

        #region "Get Studenti"
        public static async Task<List<Studenti>> GetStudente(string filtro)
        {
            using (StudentiContext context = new StudentiContext())
            {
                return await context.Studenti.Include(i => i.Corsi)
                    .Where(w => w.Nome.Contains(filtro) || w.Cognome.Contains(filtro))
                    .ToListAsync();
            }
        }
        #endregion

        #region "Elimina Studente"
        public static async Task Delete(int IdStudente)
        {
            using(StudentiContext context = new StudentiContext())
            {
                var candidate = await context.Studenti.FirstOrDefaultAsync(id => id.IdStudente == IdStudente);

                if (candidate != null)
                {
                    context.Studenti.Remove(candidate);
                    await context.SaveChangesAsync();
                }
            }  
        }
        #endregion

        #region "Aggiungere Nuovo Studente"
        public static async Task AddStudenteAsync(Studenti studente)
        {
            using (StudentiContext context = new StudentiContext())
            {
                context.Studenti.Add(studente);
                await context.SaveChangesAsync();
            }
        }
        #endregion

        #region "Aggiuornare Uno Studente"
        public static async Task EditStudenteAsync(Studenti studente)
        {
            using(StudentiContext context = new StudentiContext())
            {
                var candidate = await context.Studenti.FirstOrDefaultAsync(id => id.IdStudente == studente.IdStudente);

                if (candidate != null)
                {
                    candidate.Cognome = studente.Cognome;
                    candidate.Nome = studente.Nome;
                    candidate.DataNascita = studente.DataNascita;
                    candidate.idCorso = studente.idCorso;
                    await context.SaveChangesAsync();
                }
            }
        }
        #endregion
    }
}
