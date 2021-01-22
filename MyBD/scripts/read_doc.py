import pyodbc
from pyodbc import Error 

def convertToBinaryData(filename):
    # Convert digital data to binary format
    with open(filename, 'rb') as file:
        binaryData = file.read()
    return binaryData

def insertBLOB(type_doc,format_doc, document, date, id_to_whom,users_id):
    
    try:
        #connection = mysql.connector.connect(host='localhost',  port='33306',     database='otdel_kadr',     user='root',    password='')
                                             

        connection=pyodbc.connect("Driver={SQL Server Native Client 11.0};"
                      "Server=DESSAN-LAPTOP\SQLEXPRESS;"
                      "Database=otdel_kadr;"
                      "Trusted_Connection=yes;")

        cursor = connection.cursor()
        sql_insert_blob_query = """ INSERT INTO document
                          (type_doc,format_doc,document, date, id_to_whom,users_id) VALUES (?,?,?,?,?,?)"""

       
        file1 = convertToBinaryData(document)
        
        # Convert data into tuple format
        insert_blob_tuple = (type_doc,format_doc, file1, date, id_to_whom,users_id)
        result = cursor.execute(sql_insert_blob_query, insert_blob_tuple)
        connection.commit()
        print("Загрузка данных прошла успешно")

    except Error as error:
        print("Failed inserting BLOB data into MySQL table {}".format(error))

    finally:
        if (connection):
            cursor.close()
            connection.close()
            #print("SQL connection is closed")
def insertBLOB2(name_doc,  date,document,users_id):
    
    try:
        connection=pyodbc.connect("Driver={SQL Server Native Client 11.0};"
                      "Server=DESSAN-LAPTOP\SQLEXPRESS;"
                      "Database=otdel_kadr;"
                      "Trusted_Connection=yes;")
                                             

        cursor = connection.cursor()
        sql_insert_blob_query = """ INSERT INTO prikazy(name_doc,format_doc,date ,doc,users_id) VALUES (?,?,?,?,?)"""

       
        file1 = convertToBinaryData(document)
        
        # Convert data into tuple format
        insert_blob_tuple = (name_doc,"rtf",date,file1,users_id)
        result = cursor.execute(sql_insert_blob_query, insert_blob_tuple)
        connection.commit()
        print("Приказ успешно создан и загружен в базу данных")

    except Error as error:
        print("Failed inserting BLOB data into SQL table {}".format(error))

    finally:
        if (connection):
            cursor.close()
            connection.close()
            #print("MySQL connection is closed")
if __name__ == "__main__":
    