
-- Get all transactions
CREATE OR REPLACE FUNCTION sptransactions_getall()
RETURNS SETOF transactions AS $$
BEGIN
    RETURN QUERY SELECT * FROM transactions;
END;
$$ LANGUAGE plpgsql;

-- Get transactions by account ID
CREATE OR REPLACE FUNCTION sptransactions_getbyaccountid(accountId INT)
RETURNS SETOF transactions AS $$
BEGIN
    RETURN QUERY SELECT * FROM transactions WHERE account_id = accountId;
END;
$$ LANGUAGE plpgsql;

-- Insert transaction
CREATE OR REPLACE FUNCTION sptransactions_insert(
    p_account_id INT,
    p_amount NUMERIC,
    p_type TEXT,
    p_description TEXT,
    p_transaction_date TIMESTAMP
) RETURNS VOID AS $$
BEGIN
    INSERT INTO transactions (account_id, amount, type, description, transaction_date)
    VALUES (p_account_id, p_amount, p_type, p_description, p_transaction_date);
END;
$$ LANGUAGE plpgsql;

-- Update transaction
CREATE OR REPLACE FUNCTION sptransactions_update(
    p_id INT,
    p_account_id INT,
    p_amount NUMERIC,
    p_type TEXT,
    p_description TEXT,
    p_transaction_date TIMESTAMP
) RETURNS VOID AS $$
BEGIN
    UPDATE transactions
    SET account_id = p_account_id,
        amount = p_amount,
        type = p_type,
        description = p_description,
        transaction_date = p_transaction_date
    WHERE id = p_id;
END;
$$ LANGUAGE plpgsql;
