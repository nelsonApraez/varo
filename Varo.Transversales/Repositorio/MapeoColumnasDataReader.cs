//// ---------------------------------------------------------------------------------------------------------------
//// <copyright file="MapeoColumnasDataReader.cs">Company S.A.</copyright>
//// <author>Developer</author>
//// <email>developer@company.com</email>
//// <date>09/08/2018</date>
//// <summary>Define las funcionalidades para mapear las columnas de un DataReader a una propiedad tipada.</summary>
//// ---------------------------------------------------------------------------------------------------------------

namespace Varo.Transversales.Repositorio
{
    using System;
    using System.Data;

    /// <summary>
    /// Define las funcionalidades para mapear las columnas de un DataReader a una propiedad tipada.
    /// </summary>
    public static class MapeoColumnasDataReader
    {
        /// <summary>
        /// To the long.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="nombreCampo">The nombre campo.</param>
        /// <returns>
        /// Valor obtenido.
        /// </returns>
        public static long ToLong(this IDataRecord reader, string nombreCampo)
        {
            long resultado = 0;
            int index = 0;
            if (reader != null)
            {
                index = reader.GetOrdinal(nombreCampo);

                if (!reader.IsDBNull(index))
                {
                    resultado = reader.GetInt64(index);
                }
            }

            return resultado;
        }

        /// <summary>
        /// To the int.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="nombreCampo">The nombre campo.</param>
        /// <returns>Convierte a int.</returns>
        public static int ToInt(this IDataRecord reader, string nombreCampo)
        {
            int resultado = 0;
            int index = 0;
            if (reader != null)
            {
                index = reader.GetOrdinal(nombreCampo);

                if (!reader.IsDBNull(index))
                {
                    resultado = reader.GetInt32(index);
                }
            }

            return resultado;
        }

        /// <summary>
        /// To the byte.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="nombreCampo">The nombre campo.</param>
        /// <returns>Convierte a byte.</returns>
        public static byte ToByte(this IDataRecord reader, string nombreCampo)
        {
            byte resultado = 0;
            int index = 0;
            if (reader != null)
            {
                index = reader.GetOrdinal(nombreCampo);

                if (!reader.IsDBNull(index))
                {
                    resultado = reader.GetByte(index);
                }
            }

            return resultado;
        }

        /// <summary>
        /// To the short.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="nombreCampo">The nombre campo.</param>
        /// <returns>Short value obtained.</returns>
        public static short ToShort(this IDataRecord reader, string nombreCampo)
        {
            short resultado = 0;
            int index = 0;
            if (reader != null)
            {
                index = reader.GetOrdinal(nombreCampo);

                if (!reader.IsDBNull(index))
                {
                    resultado = reader.GetInt16(index);
                }
            }

            return resultado;
        }

        /// <summary>
        /// To the bool.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="nombreCampo">The nombre campo.</param>
        /// <returns>Bool value obtained.</returns>
        public static bool ToBool(this IDataRecord reader, string nombreCampo)
        {
            bool resultado = false;
            int index = 0;
            if (reader != null)
            {
                index = reader.GetOrdinal(nombreCampo);

                if (!reader.IsDBNull(index))
                {
                    resultado = reader.GetBoolean(index);
                }
            }

            return resultado;
        }

        /// <summary>
        /// To the decimal.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="nombreCampo">The nombre campo.</param>
        /// <returns>Decimal value obtained.</returns>
        public static decimal ToDecimal(this IDataRecord reader, string nombreCampo)
        {
            decimal resultado = 0;
            int index = 0;
            if (reader != null)
            {
                index = reader.GetOrdinal(nombreCampo);

                if (!reader.IsDBNull(index))
                {
                    resultado = reader.GetDecimal(index);
                }
            }

            return resultado;
        }

        /// <summary>
        /// To the date time.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="nombreCampo">The nombre campo.</param>
        /// <returns>Date time value obtained.</returns>
        public static DateTime ToDateTime(this IDataRecord reader, string nombreCampo)
        {
            DateTime resultado = DateTime.MinValue;
            int index = 0;
            if (reader != null)
            {
                index = reader.GetOrdinal(nombreCampo);

                if (!reader.IsDBNull(index))
                {
                    resultado = reader.GetDateTime(index);
                }
            }

            return resultado;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="nombreCampo">The nombre campo.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public static string ToString(this IDataRecord reader, string nombreCampo)
        {
            string resultado = null;
            int index = 0;
            if (reader != null)
            {
                index = reader.GetOrdinal(nombreCampo);

                if (!reader.IsDBNull(index))
                {
                    resultado = reader.GetString(index);
                }
            }

            return resultado;
        }

        /// <summary>
        /// To the Guid.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="nombreCampo">The nombre campo.</param>
        /// <returns>Guid value obtained.</returns>
        public static Guid ToGuid(this IDataRecord reader, string nombreCampo)
        {
            Guid resultado = Guid.Empty;
            int index = 0;
            if (reader != null)
            {
                index = reader.GetOrdinal(nombreCampo);

                if (!reader.IsDBNull(index))
                {
                    resultado = reader.GetGuid(index);
                }
            }

            return resultado;
        }

        /// <summary>
        /// To the long.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="nombreCampo">The nombre campo.</param>
        /// <returns>
        /// Valor obtenido.
        /// </returns>
        public static long? ToNullableLong(this IDataRecord reader, string nombreCampo)
        {
            long? resultado = null;
            int index = 0;
            if (reader != null)
            {
                index = reader.GetOrdinal(nombreCampo);

                if (!reader.IsDBNull(index))
                {
                    resultado = reader.GetInt64(index);
                }
            }

            return resultado;
        }

        /// <summary>
        /// To the nullable int.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="nombreCampo">The nombre campo.</param>
        /// <returns>Nullable int value obtained.</returns>
        public static int? ToNullableInt(this IDataRecord reader, string nombreCampo)
        {
            int? resultado = null;
            int index = 0;
            if (reader != null)
            {
                index = reader.GetOrdinal(nombreCampo);

                if (!reader.IsDBNull(index))
                {
                    resultado = reader.GetInt32(index);
                }
            }

            return resultado;
        }

        /// <summary>
        /// To the nullable byte.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="nombreCampo">The nombre campo.</param>
        /// <returns>Nullable byte value obtained.</returns>
        public static byte? ToNullableByte(this IDataRecord reader, string nombreCampo)
        {
            byte? resultado = null;
            int index = 0;
            if (reader != null)
            {
                index = reader.GetOrdinal(nombreCampo);

                if (!reader.IsDBNull(index))
                {
                    resultado = reader.GetByte(index);
                }
            }

            return resultado;
        }

        /// <summary>
        /// To the nullable short.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="nombreCampo">The nombre campo.</param>
        /// <returns>Nullable short value obtained.</returns>
        public static short? ToNullableShort(this IDataRecord reader, string nombreCampo)
        {
            short? resultado = null;
            int index = 0;
            if (reader != null)
            {
                index = reader.GetOrdinal(nombreCampo);

                if (!reader.IsDBNull(index))
                {
                    resultado = reader.GetByte(index);
                }
            }

            return resultado;
        }

        /// <summary>
        /// To the nullable bool.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="nombreCampo">The nombre campo.</param>
        /// <returns>Nullable bool value obtained.</returns>
        public static bool? ToNullableBool(this IDataRecord reader, string nombreCampo)
        {
            bool? resultado = null;
            int index = 0;
            if (reader != null)
            {
                index = reader.GetOrdinal(nombreCampo);

                if (!reader.IsDBNull(index))
                {
                    resultado = reader.GetBoolean(index);
                }
            }

            return resultado;
        }

        /// <summary>
        /// To the nullable decimal.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="nombreCampo">The nombre campo.</param>
        /// <returns>Nullable decimal value obtained.</returns>
        public static decimal? ToNullableDecimal(this IDataRecord reader, string nombreCampo)
        {
            decimal? resultado = null;
            int index = 0;
            if (reader != null)
            {
                index = reader.GetOrdinal(nombreCampo);

                if (!reader.IsDBNull(index))
                {
                    resultado = reader.GetDecimal(index);
                }
            }

            return resultado;
        }

        /// <summary>
        /// To the nullable date time.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="nombreCampo">The nombre campo.</param>
        /// <returns>Nullable datetime value obtained.</returns>
        public static DateTime? ToNullableDateTime(this IDataRecord reader, string nombreCampo)
        {
            DateTime? resultado = null;
            int index = 0;
            if (reader != null)
            {
                index = reader.GetOrdinal(nombreCampo);

                if (!reader.IsDBNull(index))
                {
                    resultado = reader.GetDateTime(index);
                }
            }

            return resultado;
        }

        /// <summary>
        /// To the nullable Guid.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="nombreCampo">The nombre campo.</param>
        /// <returns>Nullable Guid value obtained.</returns>
        public static Guid? ToNullableGuid(this IDataRecord reader, string nombreCampo)
        {
            Guid? resultado = null;
            int index = 0;
            if (reader != null)
            {
                index = reader.GetOrdinal(nombreCampo);

                if (!reader.IsDBNull(index))
                {
                    resultado = reader.GetGuid(index);
                }
            }

            return resultado;
        }
    }
}

