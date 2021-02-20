namespace DPPaint.Models
{
    public interface ICanvasMomento
    {
        byte[] GetSnapshotBytes();
        int GetOrder();
    }
}
