CREATE PROCEDURE `company_getById`(in company_id int)
BEGIN
	SELECT * FROM company WHERE id = company_id;
END