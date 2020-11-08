using Almotkaml.HR.Models;

namespace Almotkaml.HR.Abstraction
{
    public interface IBounsBusiness
    {
        BounsModel Preparehr();

        BounsModel Prepare();
        bool Submit(BounsModel model);
        bool Submithr(BounsModel model);

        bool Cancel(BounsModel model);
    }
}