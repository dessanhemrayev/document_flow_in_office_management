import mysql.connector
from mysql.connector import Error
import os
def write_file(data, filename):
    # Convert binary data to proper format and write it on Hard Disk
    with open(filename, 'wb') as file:
        file.write(data)
    file.close()

def readBLOB(emp_id ):
    
    try:
        connection = mysql.connector.connect(host='localhost',
                                             port='33306',
                                             database='otdel_kadr',
                                             user='root',
                                             password='')
                                             

        cursor = connection.cursor()


        name="D:\\Downloads\\"
      
        sql_fetch_blob_query =  "SELECT `type_doc`, `format_doc`, `document`, `date` FROM `document` WHERE id=%s"

        cursor.execute(sql_fetch_blob_query,(emp_id,))
        myresults =cursor.fetchall()

        for tup in myresults:
            name=name+tup[0]+"_"+str(tup[3].day)+"_"+str(tup[3].month)+"_"+str(tup[3].year)+"."+tup[1]
            userImage = open(name,'wb')
            userImage.write(tup[2]) #this is where the image is, in the third column n gets written to the file we just opened.
            print("Документ успешно скачан в папку D:\\Downloads")
    

    except mysql.connector.Error as error:
        print("Failed to read BLOB data from MySQL table {}".format(error))

    finally:
        if (connection.is_connected()):
            cursor.close()
            connection.close()


def readBLOB2(emp_id ):
    
    try:
        connection = mysql.connector.connect(host='localhost',
                                             port='33306',
                                             database='otdel_kadr',
                                             user='root',
                                             password='')
                                             

        cursor = connection.cursor()


        name="D:\\Downloads\\"
      
        sql_fetch_blob_query =  "SELECT  `name_doc`, `format_doc`, `date`, `doc`, (select concat(`info`.`user_name`, ' ',`info`.`surname`) from `otdel_kadr`.`info` where `info`.`users_id`=`prikazy`.`for_user_id`) FROM `prikazy` WHERE id=%s"

        cursor.execute(sql_fetch_blob_query,(emp_id,))
        myresults =cursor.fetchall()

        for tup in myresults:
            name=name+tup[0]+"_"+str(tup[2].day)+"_"+str(tup[2].month)+"_"+str(tup[2].year)+tup[4]+"."+tup[1]
            userImage = open(name,'wb')
            userImage.write(tup[3]) #this is where the image is, in the third column n gets written to the file we just opened.
            print("Документ успешно скачан в папку D:\\Downloads")
    

    except mysql.connector.Error as error:
        print("Failed to read BLOB data from MySQL table {}".format(error))

    finally:
        if (connection.is_connected()):
            cursor.close()
            connection.close()            

if __name__ == "__main__":
    # Каталог
    try:
        directory = "Downloads"
    # Путь к родительскому каталогу
        parent_dir = "D:\\"
    

        # Путь

        path = os.path.join(parent_dir, directory)
        
        if not os.path.isdir(path):
            os.mkdir(path)
    except OSError as error:
        print(error)  
    finally:
