using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Regravacao.Helpers
{
    public static class DataTableConverter
    {
        /// <summary>
        /// Converte uma lista genérica de objetos (List<T>) para um DataTable.
        /// Esta é a solução padrão no WinForms para habilitar a filtragem via BindingSource.Filter.
        /// </summary>
        /// <typeparam name="T">O tipo do objeto na lista (seu DTO, ex: RegravacaoConsultaSimplesDto).</typeparam>
        /// <param name="items">A lista de objetos a ser convertida.</param>
        /// <returns>Um DataTable contendo os dados da lista.</returns>
        public static DataTable ToDataTable<T>(List<T> items)
        {
            // Se a lista estiver vazia, retorna um DataTable vazio, mas com a estrutura correta.
            if (items == null || items.Count == 0)
            {
                DataTable emptyTable = new DataTable(typeof(T).Name);
                PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in props)
                {
                    Type colType = prop.PropertyType;
                    if (colType.IsGenericType && colType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        colType = Nullable.GetUnderlyingType(colType) ?? colType;
                    }
                    emptyTable.Columns.Add(prop.Name, colType);
                }
                return emptyTable;
            }

            DataTable dataTable = new DataTable(typeof(T).Name);

            // Obtém todas as propriedades públicas da classe T
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // 1. Cria as colunas no DataTable
            foreach (PropertyInfo prop in Props)
            {
                // Trata tipos anuláveis (Nullable<T>) para usar o tipo subjacente
                Type colType = prop.PropertyType;
                if (colType.IsGenericType && colType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    colType = Nullable.GetUnderlyingType(colType) ?? colType;
                }
                // Adiciona a coluna com o tipo de dado correto
                dataTable.Columns.Add(prop.Name, colType);
            }

            // 2. Preenche as linhas do DataTable
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    // Obtém o valor da propriedade. Se for null no objeto, usa DBNull.Value no DataTable.
                    values[i] = Props[i].GetValue(item, null) ?? DBNull.Value;
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }
    }
}