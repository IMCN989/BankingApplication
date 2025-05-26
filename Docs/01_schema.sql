
-- Create accounts table
CREATE TABLE IF NOT EXISTS accounts (
    id SERIAL PRIMARY KEY,
    user_id INT NOT NULL,
    account_number TEXT NOT NULL,
    balance NUMERIC(12, 2) NOT NULL DEFAULT 0,
    account_type TEXT NOT NULL
);
