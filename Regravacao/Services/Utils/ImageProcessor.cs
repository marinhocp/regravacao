using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace Regravacao.Services.Utils
{
    public static class ImageProcessor
    {
        private const int ThumbnailSize = 128;
        // 🎯 Fator de qualidade JPEG (0 a 100). Um valor de 80 é um bom equilíbrio entre qualidade visual aceitável e tamanho de arquivo pequeno.
        private const long JpegQuality = 80;

        // Método auxiliar para obter o encoder JPEG necessário para definir a qualidade
        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        /// <summary>
        /// Redimensiona uma imagem para um tamanho fixo (thumbnail) usando configurações de renderização padrão.
        /// </summary>
        public static Image CreateThumbnail(Image image)
        {
            int width, height;

            var ratioX = (double)ThumbnailSize / image.Width;
            var ratioY = (double)ThumbnailSize / image.Height;
            var ratio = ratioX < ratioY ? ratioX : ratioY;

            width = (int)(image.Width * ratio);
            height = (int)(image.Height * ratio);

            var newImage = new Bitmap(ThumbnailSize, ThumbnailSize);

            using (var graphics = Graphics.FromImage(newImage))
            {
                // 🎯 Removidas as configurações de HighQuality, usando Bilinear que é mais rápido e suficiente.
                graphics.InterpolationMode = InterpolationMode.Bilinear;

                int offsetX = (ThumbnailSize - width) / 2;
                int offsetY = (ThumbnailSize - height) / 2;

                graphics.DrawImage(image, offsetX, offsetY, width, height);
            }

            return newImage;
        }

        /// <summary>
        /// Converte a imagem para um array de bytes JPG, aplicando a qualidade de compressão definida (JpegQuality).
        /// </summary>
        public static byte[] ImageToByteArray(Image image)
        {
            ImageCodecInfo jpegCodec = GetEncoder(ImageFormat.Jpeg);
            if (jpegCodec == null)
            {
                // Fallback: se o encoder não for encontrado, salva com a qualidade padrão do sistema
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, ImageFormat.Jpeg);
                    return ms.ToArray();
                }
            }

            using (EncoderParameters encoderParameters = new EncoderParameters(1))
            using (MemoryStream ms = new MemoryStream())
            {
                // 🎯 Define o parâmetro de qualidade do JPEG
                encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, JpegQuality);

                // Salva a imagem com a qualidade especificada, priorizando o tamanho do arquivo
                image.Save(ms, jpegCodec, encoderParameters);

                return ms.ToArray();
            }
        }
    }
}