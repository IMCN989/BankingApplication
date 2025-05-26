
-- Get all accounts
CREATE OR REPLACE FUNCTION get_all_accounts()
RETURNS SETOF accounts AS $$
BEGIN
    RETURN QUERY SELECT * FROM accounts;
END;
$$ LANGUAGE plpgsql;

-- Get accounts by user ID
CREATE OR REPLACE FUNCTION get_accounts_by_user(p_user_id INT)
RETURNS SETOF accounts AS $$
BEGIN
    RETURN QUERY SELECT * FROM accounts WHERE user_id = p_user_id;
END;
$$ LANGUAGE plpgsql;

-- Create new account
CREATE OR REPLACE FUNCTION create_account(
    p_user_id INT,
    p_account_number TEXT,
    p_balance NUMERIC,
    p_account_type TEXT
) RETURNS INT AS $$
DECLARE
    new_id INT;
BEGIN
    INSERT INTO accounts (user_id, account_number, balance, account_type)
    VALUES (p_user_id, p_account_number, p_balance, p_account_type)
    RETURNING id INTO new_id;

    RETURN new_id;
END;
$$ LANGUAGE plpgsql;

-- Update account
CREATE OR REPLACE FUNCTION update_account(
    p_id INT,
    p_account_number TEXT,
    p_balance NUMERIC,
    p_account_type TEXT
) RETURNS BOOLEAN AS $$
BEGIN
    UPDATE accounts
    SET account_number = p_account_number,
        balance = p_balance,
        account_type = p_account_type
    WHERE id = p_id;

    RETURN FOUND;
END;
$$ LANGUAGE plpgsql;

-- Delete account
CREATE OR REPLACE FUNCTION delete_account(p_id INT)
RETURNS BOOLEAN AS $$
BEGIN
    DELETE FROM accounts WHERE id = p_id;
    RETURN FOUND;
END;
$$ LANGUAGE plpgsql;
