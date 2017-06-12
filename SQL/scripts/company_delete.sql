CREATE PROCEDURE `company_delete`(in company_id int)
BEGIN
	DELETE FROM company WHERE id = company_id;
END