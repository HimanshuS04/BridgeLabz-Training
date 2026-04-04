using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

public class AddressBookRepository
{
    private readonly string ConnectionString;

    public AddressBookRepository(string connectionString)
    {
        ConnectionString = connectionString;
    }

    // Create new AddressBook, return its AddressBookId
    public int CreateAddressBook(string name, string description)
    {
        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
            conn.Open();

            string sql = @"
            INSERT INTO AddressBooks (Name, Description)
            OUTPUT INSERTED.AddressBookId
            VALUES (@Name, @Description);";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Description", (object?)description ?? DBNull.Value);

                int id = (int)cmd.ExecuteScalar();
                return id;
            }
        }
    }

    public List<AddressBookInfo> GetAddressBooks()
    {
        var list = new List<AddressBookInfo>();

        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
            conn.Open();

            string sql = "SELECT AddressBookId, Name, Description FROM AddressBooks ORDER BY Name;";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new AddressBookInfo
                    {
                        AddressBookId = (int)reader["AddressBookId"],
                        Name          = reader["Name"] as string,
                        Description   = reader["Description"] as string
                    });
                }
            }
        }

        return list;
    }

    public int? GetAddressBookIdByName(string name)
    {
        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
            conn.Open();

            string sql = "SELECT AddressBookId FROM AddressBooks WHERE Name = @Name;";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Name", name);

                object result = cmd.ExecuteScalar();
                if (result == null || result == DBNull.Value)
                    return null;

                return (int)result;
            }
        }
    }

    // CONTACT CRUD for a given AddressBookId

    public void AddContact(int addressBookId, Contact contact)
    {
        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
            conn.Open();

            string sql = @"
INSERT INTO Contacts (AddressBookId, FirstName, LastName, Address, City, State, Zip, Phone, Email)
VALUES (@AddressBookId, @FirstName, @LastName, @Address, @City, @State, @Zip, @Phone, @Email);";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@AddressBookId", addressBookId);
                cmd.Parameters.AddWithValue("@FirstName",  (object?)contact.GetFirstName()     ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LastName",   (object?)contact.GetLastName()      ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Address",    (object?)contact.GetAddress()       ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@City",       (object?)contact.GetCity()          ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@State",      (object?)contact.GetState()         ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Zip",        (object?)contact.GetZip()           ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Phone",      (object?)contact.GetPhoneNumber()   ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Email",      (object?)contact.GetEmail()         ?? DBNull.Value);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627) // unique index violation (duplicate First+Last in same book)
                    {
                        Console.WriteLine("Error: A contact with the same first and last name already exists in this address book.");
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }
    }

    public List<Contact> GetContactsByAddressBook(int addressBookId)
    {
        var list = new List<Contact>();

        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
            conn.Open();

            string sql = @"
SELECT FirstName, LastName, Address, City, State, Zip, Phone, Email
FROM Contacts
WHERE AddressBookId = @AddressBookId
ORDER BY FirstName, LastName;";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@AddressBookId", addressBookId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Contact c = new Contact();
                        c.SetFirstName(reader["FirstName"] as string);
                        c.SetLastName(reader["LastName"] as string);
                        c.SetAddress(reader["Address"] as string);
                        c.SetCity(reader["City"] as string);
                        c.SetState(reader["State"] as string);
                        c.SetZip(reader["Zip"] as string);
                        c.SetPhoneNumber(reader["Phone"] as string);
                        c.SetEmail(reader["Email"] as string);

                        list.Add(c);
                    }
                }
            }
        }

        return list;
    }

    public bool UpdateContactByName(int addressBookId, string firstName, string lastName, Contact updated)
    {
        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
            conn.Open();

            string sql = @"
UPDATE Contacts
SET Address = @Address,
    City    = @City,
    State   = @State,
    Zip     = @Zip,
    Phone   = @Phone,
    Email   = @Email
WHERE AddressBookId = @AddressBookId
  AND FirstName = @FirstName
  AND LastName  = @LastName;";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@AddressBookId", addressBookId);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName",  lastName);
                cmd.Parameters.AddWithValue("@Address",   (object?)updated.GetAddress()     ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@City",      (object?)updated.GetCity()        ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@State",     (object?)updated.GetState()       ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Zip",       (object?)updated.GetZip()         ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Phone",     (object?)updated.GetPhoneNumber() ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Email",     (object?)updated.GetEmail()       ?? DBNull.Value);

                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }
    }

    public bool DeleteContactByName(int addressBookId, string firstName, string lastName)
    {
        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
            conn.Open();

            string sql = @"
DELETE FROM Contacts
WHERE AddressBookId = @AddressBookId
  AND FirstName = @FirstName
  AND LastName  = @LastName;";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@AddressBookId", addressBookId);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName",  lastName);

                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }
    }
}