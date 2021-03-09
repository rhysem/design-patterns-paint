using System.Drawing;

namespace DPPaint.Models
{
    public class CanvasMomento : ICanvasMomento
    {
        private readonly int _order;
        private readonly byte[] _snapshotBytes;

        public CanvasMomento(int order, Image snapshot, byte[] snapshotBytes)
        {
            _order = order;
            _snapshotBytes = snapshotBytes;
        }

        public int GetOrder()
        {
            return _order;
        }

        public byte[] GetSnapshotBytes()
        {
            return _snapshotBytes;
        }
    }
}
