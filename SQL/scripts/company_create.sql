CREATE PROCEDURE `company_create`(

in comp_id int,
in comp_name varchar(300), 
in comp_description varchar(300), 
in comp_email varchar(100), 
in comp_address varchar(50), 
in comp_zipcode varchar(100),
in comp_person_no int,
in comp_city_id int,
in comp_phone_no varchar(20),
in comp_state_id int,
in comp_is_active bit
)
BEGIN

	IF comp_id = 0 THEN
		INSERT INTO company 
        (name, description, email, address, zipcode, person_no, city_id, phone_no, state_id, is_active)
		 VALUES
		(comp_name, comp_description, comp_email, comp_address, comp_zipcode, comp_person_no, comp_city_id, comp_phone_no, comp_state_id, comp_is_active);
    
    ELSE
		UPDATE company 
		set name = comp_name, description = comp_description, email = comp_email, address = comp_address,
		zipcode = comp_zipcode, person_no = comp_person_no, city_id = comp_city_id, phone_no = comp_phone_no, 
		state_id = comp_state_id, is_active = comp_is_active WHERE  id = comp_id;
    END IF;    
END