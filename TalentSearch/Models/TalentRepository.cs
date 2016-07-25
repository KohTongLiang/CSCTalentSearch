using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TalentSearch.Models
{
    public class TalentRepository : InterfaceTalentRepository
    {
        private List<Talent> talents = new List<Talent>();
        private int _nextId = 1;

        private String ToUrl(String ShortName)
        {
            return "http://res.cloudinary.com/talentsearch/image/upload/v1466085085/talents/" + ShortName + ".jpg";
        }

        public TalentRepository()
        {
            Add(new Talent
            {
                Name = "Barot Bellingham",
                ShortName = "Barot_Bellingham",
                Reknown = "Royal Academy of Painting and Sculpture",
                Bio = "Barot has just finished his final year at The Royal Academy of Painting and Sculpture, where he excelled in glass etching paintings and portraiture. Hailed as one of the most diverse artists of his generation, Barot is equally as skilled with watercolors as he is with oils, and is just as well-balanced in different subject areas. Barot's collection entitled \"The Un-Collection\" will adorn the walls of Gilbert Hall, depicting his range of skills and sensibilities - all of them, uniquely Barot, yet undeniably different",
                ImageLink = ToUrl("Barot_Bellingham")
            });

            Add(new Talent
            {
                Id = 1,
                Name = "Jonathan Ferrar",
                ShortName = "Jonathan_Ferrar",
                Reknown = "Artist to Watch in 2012",
                Bio = "The Artist to Watch in 2012 by the London Review, Johnathan has already sold one of the highest priced-commissions paid to an art student, ever on record. The piece, entitled Gratitude Resort, a work in oil and mixed media, was sold for $750,000 and Jonathan donated all the proceeds to Art for Peace, an organization that provides college art scholarships for creative children in developing nations",
                ImageLink = ToUrl("Jonathan_Ferrar")
            });

            Add(new Talent
            {
                Id = 2,
                Name = "Hillary Hewitt Goldwynn-Post",
                ShortName = "Hillary_Goldwynn",
                Reknown = "New York University",
                Bio = "Hillary is a sophomore art sculpture student at New York University, and has already won all the major international prizes for new sculptors, including the Divinity Circle, the International Sculptor's Medal, and the Academy of Paris Award. Hillary's CAC exhibit features 25 abstract watercolor paintings that contain only water images including waves, deep sea, and river.",
                ImageLink = ToUrl("Hillary_Goldwynn")
            });

            Add(new Talent
            {
                Id = 3,
                Name = "Hassum Harrod",
                ShortName = "Hassum_Harrod",
                Reknown = "Art College in New Dehli",
                Bio = "The Art College in New Dehli has sponsored Hassum on scholarship for his entire undergraduate career at the university, seeing great promise in his contemporary paintings of landscapes - that use equal parts muted and vibrant tones, and are almost a contradiction in art. Hassum will be speaking on \"The use and absence of color in modern art\" during Thursday's agenda.",
                ImageLink = ToUrl("Hassum_Harrod")
            });

        }

        public IEnumerable<Talent> GetAll()
        {
            return talents;
        }

        public Talent Get(int id)
        {
            return talents.Find(t => t.Id == id);
        }

        public Talent Add(Talent talent)
        {
            if (talent == null)
            {
                throw new ArgumentNullException("talent");
            }
            talent.Id = _nextId++;
            talents.Add(talent);
            return talent;
        }

        public void Remove(int id)
        {
            talents.RemoveAll(t => t.Id == id);
        }

        public bool Update(Talent talent)
        {
            if (talent == null)
            {
                throw new ArgumentNullException("talent");
            }
            int index = talents.FindIndex(t => t.Id == talent.Id);
            if (index == -1)
            {
                return false;
            }
            ////update, change index location to bottom
            //talents.RemoveAt(index);
            //talents.Add(talent);

            //update, keep index location
            talents[index] = talent;

            return true;
        }
    }
}