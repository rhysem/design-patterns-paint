using System.Drawing;

namespace DPPaint.Models
{
    public class CanvasMomento : ICanvasMomento
    {
        private readonly int Order;
        private readonly byte[] SnapshotBytes;

        public CanvasMomento(int order, Image snapshot, byte[] snapshotBytes)
        {
            Order = order;
            SnapshotBytes = snapshotBytes;
        }

        public int GetOrder()
        {
            return Order;
        }

        public byte[] GetSnapshotBytes()
        {
            return SnapshotBytes;
        }
    }
}
