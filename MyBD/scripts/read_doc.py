import mysql.connector
from mysql.connector import Error

def convertToBinaryData(filename):
    # Convert digital data to binary format
    with open(filename, 'rb') as file:
        binaryData = file.read()
    return binaryData

def insertBLOB(type_doc,format_doc, document, date, id_to_whom,users_id):
    
    try:
        connection = mysql.connector.connect(host='localhost',
                                             port='33306',
                                             database='otdel_kadr',
                                             user='root',
                                             password='')
                                             

        cursor = connection.cursor()
        sql_insert_blob_query = """ INSERT INTO document
                          (type_doc,format_doc,document, date, id_to_whom,users_id) VALUES (%s,%s,%s,%s,%s,%s)"""

       
        file1 = convertToBinaryData(document)
        
        # Convert data into tuple format
        insert_blob_tuple = (type_doc,format_doc, file1, date, id_to_whom,users_id)
        result = cursor.execute(sql_insert_blob_query, insert_blob_tuple)
        connection.commit()
        print("Загрузка данных прошла успешно")

    except mysql.connector.Error as error:
        print("Failed inserting BLOB data into MySQL table {}".format(error))

    finally:
        if (connection.is_connected()):
            cursor.close()
            connection.close()
            #print("MySQL connection is closed")
def insertBLOB2(name_doc,  date,document,users_id):
    
    try:
        connection = mysql.connector.connect(host='localhost',
                                             port='33306',
                                             database='otdel_kadr',
                                             user='root',
                                             password='')
                                             

        cursor = connection.cursor()
        sql_insert_blob_query = """ INSERT INTO prikazy
                          (name_doc,date,doc,users_id) VALUES (%s,%s,%s,%s)"""

       
        file1 = convertToBinaryData(document)
        
        # Convert data into tuple format
        insert_blob_tuple = (name_doc,date, file1,users_id)
        result = cursor.execute(sql_insert_blob_query, insert_blob_tuple)
        connection.commit()
        print("Приказ успешно создан и загружен в базу данных")

    except mysql.connector.Error as error:
        print("Failed inserting BLOB data into MySQL table {}".format(error))

    finally:
        if (connection.is_connected()):
            cursor.close()
            connection.close()
            #print("MySQL connection is closed")
if __name__ == "__main__":
    #insertBLOB("Заявление","pdf",f"C:\\Users\\dessa\\Downloads\\Doc1.docx","18.11.2020",2,1)
